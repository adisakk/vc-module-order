﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Domain.Order.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.ExportImport;

namespace VirtoCommerce.OrderModule.Web.ExportImport
{
    public sealed class BackupObject
    {
        public BackupObject()
        {
            CustomerOrders = new List<CustomerOrder>();
        }
        public ICollection<CustomerOrder> CustomerOrders { get; set; }
    }

    public sealed class OrderExportImport
    {
        private readonly ICustomerOrderSearchService _customerOrderSearchService;
        private readonly ICustomerOrderService _customerOrderService;

        public OrderExportImport(ICustomerOrderSearchService customerOrderSearchService, ICustomerOrderService customerOrderService)
        {
            _customerOrderSearchService = customerOrderSearchService;
            _customerOrderService = customerOrderService;
        }

        public void DoExport(Stream backupStream, Action<ExportImportProgressInfo> progressCallback)
        {
            var backupObject = GetBackupObject(progressCallback);
            backupObject.SerializeJson(backupStream);
        }

        public void DoImport(Stream backupStream, Action<ExportImportProgressInfo> progressCallback)
        {
            var backupObject = backupStream.DeserializeJson<BackupObject>();

            var progressInfo = new ExportImportProgressInfo();
            var totalCount = backupObject.CustomerOrders.Count;

            const int take = 20;
            for (var skip = 0; skip < totalCount; skip += take)
            {
                _customerOrderService.SaveChanges(backupObject.CustomerOrders.Skip(skip).Take(take).ToArray());

                progressInfo.Description = string.Format(CultureInfo.InvariantCulture, "{0} of {1} orders imported", Math.Min(skip + take, totalCount), totalCount);
                progressCallback(progressInfo);
            }
        }

        private BackupObject GetBackupObject(Action<ExportImportProgressInfo> progressCallback)
        {
            var retVal = new BackupObject();
            var progressInfo = new ExportImportProgressInfo();

            var searchCriteria = AbstractTypeFactory<CustomerOrderSearchCriteria>.TryCreateInstance();
            searchCriteria.ResponseGroup = CustomerOrderResponseGroup.Default.ToString();
            searchCriteria.Take = 0;

            var searchResponse = _customerOrderSearchService.SearchCustomerOrders(searchCriteria);

            const int take = 20;
            for (var skip = 0; skip < searchResponse.TotalCount; skip += take)
            {
                searchCriteria = AbstractTypeFactory<CustomerOrderSearchCriteria>.TryCreateInstance();
                searchCriteria.ResponseGroup = CustomerOrderResponseGroup.Full.ToString();
                searchCriteria.WithPrototypes = true;
                searchCriteria.Skip = skip;
                searchCriteria.Take = take;

                searchResponse = _customerOrderSearchService.SearchCustomerOrders(searchCriteria);

                progressInfo.Description = string.Format(CultureInfo.InvariantCulture, "{0} of {1} orders loading", Math.Min(skip + take, searchResponse.TotalCount), searchResponse.TotalCount);
                progressCallback(progressInfo);
                retVal.CustomerOrders.AddRange(searchResponse.Results);
            }

            //Do not serialize shipment and payment methods
            var allPayments = retVal.CustomerOrders.SelectMany(x => x.InPayments);
            foreach (var payment in allPayments)
            {
                payment.PaymentMethod = null;
            }

            var allShipments = retVal.CustomerOrders.SelectMany(x => x.Shipments);
            foreach (var shipment in allShipments)
            {
                shipment.ShippingMethod = null;
            }

            return retVal;
        }
    }
}

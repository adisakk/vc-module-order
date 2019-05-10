using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Omu.ValueInjecter;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.OrderModule.Data.Utilities;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.OrderModule.Data.Model
{
    public class SubOperationEntity : AuditableEntity
    {
        [Required]
        [StringLength(64)]
        public string Number { get; set; }
        public bool IsApproved { get; set; }
        [StringLength(64)]
        public string Status { get; set; }
        [StringLength(2048)]
        public string Comment { get; set; }
        [Required]
        [StringLength(3)]
        public string Currency { get; set; }
        [Column(TypeName = "Money")]
        public decimal Sum { get; set; }

        public bool IsCancelled { get; set; }
        public DateTime? CancelledDate { get; set; }
        [StringLength(2048)]
        public string CancelReason { get; set; }

        public string OwnerName { get; set; }

        public virtual CustomerOrderEntity CustomerOrder { get; set; }
        public string CustomerOrderId { get; set; }

        public virtual SubOperation ToModel(SubOperation operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            operation.InjectFrom(this);
            
            return operation;
        }

        public virtual SubOperationEntity FromModel(SubOperation subOperation, PrimaryKeyResolvingMap pkMap)
        {
            if (subOperation == null)
                throw new ArgumentNullException(nameof(subOperation));

            pkMap.AddPair(subOperation, this);

            this.InjectFrom(subOperation);

            return this;
        }

        public virtual void Patch(SubOperationEntity subOperation)
        {
            if (subOperation == null)
                throw new ArgumentNullException(nameof(subOperation));

            subOperation.Comment = Comment;
            subOperation.Currency = Currency;
            subOperation.Number = Number;
            subOperation.Status = Status;
            subOperation.IsCancelled = IsCancelled;
            subOperation.CancelledDate = CancelledDate;
            subOperation.CancelReason = CancelReason;
            subOperation.IsApproved = IsApproved;
            subOperation.Sum = Sum;
            subOperation.OwnerName = OwnerName;
        }
    }
}

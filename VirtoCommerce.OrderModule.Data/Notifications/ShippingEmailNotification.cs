using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Platform.Core.Notifications;

namespace VirtoCommerce.OrderModule.Data.Notifications
{
    public class ShippingEmailNotification : OrderEmailNotificationBase
    {
        public ShippingEmailNotification(IEmailNotificationSendingGateway gateway)
            : base(gateway)
        {
        }

        /// <summary>
        /// For templates back compatibility
        /// </summary>
        [NotificationParameter("Order")]
        public CustomerOrder Order => CustomerOrder;
    }
}

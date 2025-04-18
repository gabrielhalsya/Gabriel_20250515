using System.ComponentModel.DataAnnotations;

namespace LogistikApp.Models
{
    public class Shipment
    {
        [Key]
        public string NoResi { get; set; }

        public SenderInfo Sender { get; set; } = new SenderInfo();
        public RecipientInfo Recipient { get; set; } = new RecipientInfo();
        public PackageInfo Package { get; set; } = new PackageInfo();

        public ICollection<ShipmentStatusHistory> StatusHistory { get; set; } = new List<ShipmentStatusHistory>();
    }












}

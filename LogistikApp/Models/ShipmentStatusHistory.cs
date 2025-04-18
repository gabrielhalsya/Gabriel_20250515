using System.ComponentModel.DataAnnotations;

namespace LogistikApp.Models
{
    public class ShipmentStatusHistory
    {
        [Key]
        public int Id { get; set; }
        public string ShipmentNoResi { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime StatusDate { get; set; }
    }
}

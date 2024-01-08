using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierWebApp.Models
{
    public class DeliveryItem
    {
        [Key]
        public int DeliveryId { get; set; }
        public int ItemId { get; set; }

        [ForeignKey("DeliveryId")]
        public virtual Delivery Delivery { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }
}

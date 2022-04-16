using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace CourierWebApp.Models
{
    public class Delivery : IEnumerable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Choose a unit")]
        public int UnitId { get; set; }
        public virtual Units Unit { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Courier { get; set; }
        public DateTime Date { get; set; }

        public Delivery()
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

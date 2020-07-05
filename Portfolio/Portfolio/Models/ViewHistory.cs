using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ViewHistory
    {
        [Key]
        public int V_ID { get; set; }
        public string IP { get; set; }
        public DateTime UTC_DateTime { get; set; } = DateTime.UtcNow;
    }
}

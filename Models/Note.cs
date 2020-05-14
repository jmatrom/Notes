using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Models
{
    public class Note
    {
        public int ID { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Created in")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string TextNote{ get; set; }

        [MaxLength(6)]
        public string Color { get; set; }
    }
}

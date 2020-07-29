using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computony.Models
{
    public class Cat
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<SubCat> SubCats { get; set; }
    }
}
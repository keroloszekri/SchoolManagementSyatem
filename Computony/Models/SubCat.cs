using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Computony.Models
{
    public class SubCat
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Student> Products { get; set; }

        public int CatID { get; set; }
        [ForeignKey("CatID")]
        public virtual Cat Cat { get; set; }
    }
}
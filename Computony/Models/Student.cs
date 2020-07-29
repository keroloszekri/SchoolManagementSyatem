using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computony.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }

        public int SubCatID { get; set; }
        [ForeignKey("SubCatID")]
        public virtual SubCat SubCat { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}
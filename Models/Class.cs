using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace EF_Core.Models
{

    [Table("Class")]
    public class Class
    {
        [Key]
        public int ID { get; set; }

        public string ClassName { get; set; }
        //public ICollection<Students> Students{get; set;}
    }
}
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreMVC.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int CATEGORYID { get; set; }
        [ForeignKey("CATEGORYID")]
        [ValidateNever]
        public Category CATEGORY { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string SIZE { get; set; }
        [Required]
        [Range (1, 10000)]
        public double PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        [ValidateNever]
        public string IMAGEURL { get; set; }
    }
}

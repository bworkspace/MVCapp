using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoApp.Models
{
    public class Customer
    {
        public int Accountno { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Branchname { get; set; }
        [Required]
        public string IFSC { get; set; }
        [Required]
        public int Balance { get; set; }
    }
}
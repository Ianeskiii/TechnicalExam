using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace technicalExam.Models
{
    public class spokenToGuests
    {
        [Key]
        [Required]
        public string ResID { get; set; }

        [Required]
        public string userEmail { get; set; }
    }
}
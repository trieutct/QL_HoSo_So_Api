using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_QLHoSo_So.Model.Entities
{
    public class User:BaseEntity
    {
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; }
        [MinLength(5)]
        public string Password { get; set; }
        [MinLength(5)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string? Birthday { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
    }
}

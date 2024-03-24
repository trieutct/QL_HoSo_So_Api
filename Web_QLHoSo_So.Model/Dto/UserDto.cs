using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_QLHoSo_So.Model.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Birthday { get; set; }
        public string? Phone { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_QLHoSo_So.Model.Entities
{
    public class Kho : BaseEntity
    {
        public string MaKho { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
    }
}

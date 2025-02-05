using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Dtos
{
    public class RoomToReturnDtos
    {
        public string Number { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public int DepartmentId { get; set; }
        public int FloorNumber { get; set; }
    }
}

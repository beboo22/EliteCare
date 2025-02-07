using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Dtos
{
    public class RoomReturnToAppointmentDtos
    {
        public string Number { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public int DepartmentName { get; set; }
        public int FloorNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.DTO
{
    public class EmployeeDTO
    {
        public List<Department> Department { get; set; }
        public List<PositionDTO> Posiiton { get; set; }
        public List<EmployeeDetailDTO> Employees { get; set; }
    }
}

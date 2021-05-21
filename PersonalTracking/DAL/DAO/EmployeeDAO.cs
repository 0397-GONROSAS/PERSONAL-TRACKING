using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class EmployeeDAO : EmployeeContext
    {
        public static void AddEmployee(Employee employee)
        {
            try
            {
                db.Employee.InsertOnSubmit(employee);
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EmployeeDetailDTO> GetEmployees()
        {
            List<EmployeeDetailDTO> employeelist = new List<EmployeeDetailDTO>();
            var list = (from e in db.Employee
                        join d in db.Department on e.DepartmentID equals d.ID
                        join p in db.Position on e.PositionID equals p.ID
                        select new
                        {
                            UserNo = e.UserNo,
                            Name = e.Name,
                            Surname = e.Surname,
                            EmployeeID = e.ID,
                            Password = e.Password,
                            DepartmentName = d.DepartmentName,
                            PositionName = p.PositionName,
                            DepartmentID = e.DepartmentID,
                            PositionID = e.PositionID,
                            isAdmin = e.IsAdmin,
                            Salary = e.Salary,
                            ImagePath = e.ImagePath,
                            Birthday = e.Birthday,
                            Addres = e.Address
                        } ).OrderBy(x=>x.UserNo).ToList(); 
            foreach( var item in list)
            {
                EmployeeDetailDTO dto = new EmployeeDetailDTO();
                dto.Name = item.Name;
                dto.UserNo = item.UserNo;
                dto.Surname = item.Surname;
                dto.EmployeeID = item.EmployeeID;
                dto.Password = item.Password;
                dto.DepartmentID = item.DepartmentID;
                dto.DepartmentName = item.DepartmentName;
                dto.PositionID = item.PositionID;
                dto.PositionName = item.PositionName;
                dto.IsAdmin = item.isAdmin;
                dto.Salary = item.Salary;
                dto.ImagePath = item.ImagePath;
                dto.Birthday = item.Birthday;
                dto.Address = item.Addres;
                employeelist.Add(dto);
            }
            return employeelist;
        }

        public static void DeleteEmployee(int employeeID)
        {
            try
            {
                Employee employee = db.Employee.First(x => x.ID == employeeID);
                db.Employee.DeleteOnSubmit(employee);
                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateEmployee(Position position)
        {
            List<Employee> list = db.Employee.Where(x => x.PositionID == position.ID).ToList();
            foreach(var item in list)
            {
                item.DepartmentID = position.DepartmentID;
            }
            db.SubmitChanges();
        }

        public static void UpdateEmployee(Employee employee)
        {
            try
            {
                Employee em = db.Employee.First(x => x.ID == employee.ID);
                em.UserNo = employee.UserNo;
                em.Name = employee.Name;
                em.Surname = employee.Surname;
                em.IsAdmin = employee.IsAdmin;
                em.Birthday = employee.Birthday;
                em.Address = employee.Address;
                em.DepartmentID = employee.DepartmentID;
                em.PositionID = employee.PositionID;
                em.Salary = employee.Salary;
                em.Password = employee.Password;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateEmployee(int employeeID, int amount)
        {
            try
            {
                Employee employee = db.Employee.First(x => x.ID == employeeID);
                employee.Salary = amount;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Employee> GetEmployees(int v, string text)
        {
            try
            {
                List<Employee> list = db.Employee.Where(x => x.UserNo == v && x.Password == text).ToList();
                return list;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Employee> GetUsers(int v)
        {
            return db.Employee.Where(x => x.UserNo == v).ToList();
        }
    }
}

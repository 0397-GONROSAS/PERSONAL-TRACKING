using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PermissionDAO : EmployeeContext
    {
        public static void AddPermission(Permission permission)
        {
            try
            {
                db.Permission.InsertOnSubmit(permission);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PermissionState> GetStates()
        {
            return db.PermissionState.ToList();
        }

        public static List<PermissionDetailDTO> GetPermissions()
        {
            List<PermissionDetailDTO> permissions = new List<PermissionDetailDTO>();

            var list = ( from p in db.Permission
                         join s in db.PermissionState on p.PermissionState equals s.ID
                         join e in db.Employee on p.EmployeeID equals e.ID
                         select new
                         {
                             UserNo = e.UserNo,
                             name = e.Name,
                             surname = e.Surname,
                             StateName = s.StateName,
                             StateID = p.PermissionState,
                             startdate = p.PermissionStartDate,
                             enddate = p.PermissionEndDate,
                             employeeID = p.EmployeeID,
                             PermissionID = p.ID,
                             explanation = p.PermissionExplain,
                             Dayamount = p.PermissionDay,
                             departmentID = e.DepartmentID,
                             positionID = e.PositionID
                         }).OrderBy(x=>x.startdate).ToList();

            foreach(var item in list)
                {
                PermissionDetailDTO dto = new PermissionDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.name;
                dto.Surname = item.surname;
                dto.StateName = item.StateName;
                dto.StartDay = item.startdate;
                dto.EndDay = item.enddate;
                dto.EmployeeID = item.employeeID;
                dto.PermissionDayAmount = item.Dayamount;
                dto.PositionID = item.positionID;
                dto.Sate = item.StateID;
                dto.Explanation = item.explanation;
                dto.DepartmentID = item.departmentID;
                dto.PositionID = item.PermissionID;
                dto.PermissionID = item.PermissionID;
                permissions.Add(dto);
            }

            return permissions;
        }

        public static void DeletePermission(int permissionID)
        {
            try
            {
                Permission pr = db.Permission.First(x => x.ID == permissionID);
                db.Permission.DeleteOnSubmit(pr);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePermission(int permissionID, int approved)
        {
            try
            {
                Permission pr = db.Permission.First(x => x.ID == permissionID);
                pr.PermissionState = approved;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePermission(Permission permission)
        {
            try
            {
                Permission pr = db.Permission.First(x => x.ID == permission.ID);
                pr.PermissionStartDate = permission.PermissionStartDate;
                pr.PermissionEndDate = permission.PermissionEndDate;
                pr.PermissionDay = permission.PermissionDay;
                pr.PermissionExplain = permission.PermissionExplain;
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

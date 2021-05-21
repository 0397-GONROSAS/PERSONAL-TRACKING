using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class TaskDAO : EmployeeContext
    {
        public static List<TaskDetailDTO> GetTasks { get; set; }

        public static List<TaskState> GetTaskStates()
        {
            return db.TaskState.ToList();
        }

        public static void AddTask(Task task)
        {
            try
            {
                db.Task.InsertOnSubmit(task);
                db.SubmitChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TaskDetailDTO> getTasks()
        {
            List<TaskDetailDTO> tasklist = new List<TaskDetailDTO>();
            var list = (from ta in db.Task
                        join s in db.TaskState on ta.TaskState equals s.ID
                        join e in db.Employee on ta.EmployeeID equals e.ID
                        join d in db.Department on e.DepartmentID equals d.ID
                        join p in db.Position on e.PositionID equals p.ID
                        select new {
                taskID = ta.ID,
                title = ta.TaskTitle,
                content = ta.TaskContent,
                stardate = ta.TaskStartDate,
                deleverydate = ta.TaskDeliveryDate,
                taskstatename = s.StateName,
                taskstateID = ta.TaskState,
                userno = e.UserNo,
                name = e.Name,
                employeeID = ta.EmployeeID,
                surname = e.Surname,
                position = p.PositionName,
                departmentname = d.DepartmentName,
                positionID = e.PositionID,
                departmentID = e.DepartmentID}).OrderBy(x=>x.stardate).ToList();
            

            foreach(var item in list)
            {
                TaskDetailDTO dto = new TaskDetailDTO();
                dto.TaskID = item.taskID;
                dto.Title = item.title;
                dto.Content = item.content;
                dto.TaskStartDate = item.stardate;
                dto.TaskDeliveryDate = item.deleverydate;
                dto.TaskStateName = item.taskstatename;
                dto.taskStateID = item.taskstateID;
                dto.UserNo = item.userno;
                dto.Name = item.name;
                dto.Surname = item.surname;
                dto.DepartmentName = item.departmentname;
                dto.PositionID = item.positionID;
                dto.PositionName = item.position;
                dto.EmployeeID = item.employeeID;
                tasklist.Add(dto);
            }
            return tasklist;
        }

        public static void ApproveTask(int taskID, bool isAdmin)
        {
            try
            {
                Task ts = db.Task.First(x => x.ID == taskID);
                if (isAdmin)
                    ts.TaskState = TaskStates.Approved;
                else
                    ts.TaskState = TaskStates.Delivered;
                ts.TaskDeliveryDate = DateTime.Today;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteTask(int taskID)
        {
            try
            {
                Task ts = db.Task.First(x => x.ID == taskID);
                db.Task.DeleteOnSubmit(ts);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateTask(Task task)
        {
            try
            {
                Task ts = db.Task.First(x => x.ID == task.ID);
                ts.TaskTitle = task.TaskTitle;
                ts.TaskContent = task.TaskContent;
                ts.TaskState = task.TaskState;
                ts.EmployeeID = task.EmployeeID;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

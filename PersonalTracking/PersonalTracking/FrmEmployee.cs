using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DTO;
using System.IO;
namespace PersonalTracking
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.IsNumber(e);
        }

        EmployeeDTO dto = new EmployeeDTO();
        public EmployeeDetailDTO  detail = new EmployeeDetailDTO();
        public bool isUpdate = false;
        string imagepath = "";
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            dto = EmployeeBLL.GetAll();
            cmbDepartment.DataSource = dto.Department;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbPosition.DataSource = dto.Posiiton;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "ID" ;
            cmbPosition.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            combofull = true;
            if(isUpdate)
            {
                txtUserNo.Text = detail.UserNo.ToString();
                txtName.Text = detail.Name;
                txtSurname.Text = detail.Surname;
                txtPassword.Text = detail.Password;
                chAdmin.Checked = Convert.ToBoolean(detail.IsAdmin);
                txtAddres.Text = detail.Address;
                dateTimePicker1.Value = Convert.ToDateTime(detail.Birthday);
                cmbDepartment.SelectedValue = detail.DepartmentID;
                cmbPosition.SelectedValue = detail.PositionID;
                txtSalary.Text = detail.Salary.ToString();
                imagepath = Application.StartupPath + "\\Images\\" + detail.ImagePath;
                txtImagePath.Text = imagepath;
                pictureBox1.ImageLocation = imagepath;

                if(!UserStatic.isAdmin)
                {
                    chAdmin.Enabled = false;
                    txtUserNo.Enabled = false;
                    txtSalary.Enabled = false;
                    cmbDepartment.Enabled = false;
                    cmbPosition.Enabled = false;
                }
            }
        }
        bool combofull = false;
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combofull)
            {
                int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbPosition.DataSource = dto.Posiiton.Where(x => x.DepartmentID == departmentID).ToList();

            }
        }
        string filename = ""; //Creando variable unica para la imagen del empleado
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                txtImagePath.Text = openFileDialog1.FileName;
                string Unique = Guid.NewGuid().ToString();
                filename += Unique + openFileDialog1.SafeFileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim() == "")
            {
                MessageBox.Show("You missed the name");
            }else if(txtSurname.Text.Trim() == "")
            {

            }
            else if (txtImagePath.Text.Trim() == "")
            {
                MessageBox.Show("You missed the Employee Image");
            }
            else if (txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("You missed the salary");
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("You missed the department");
            }
            else if (cmbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("You missed the Position");
            }
            else if (txtUserNo.Text.Trim() =="")
            {
                MessageBox.Show("You missed the User Number");
            }
            else if (txtPassword.Text.Trim() =="")
            {
                MessageBox.Show("You missed the password");
            }
            else
            {
                Employee employee = new Employee();
                if (!isUpdate)
                {
                    if (!EmployeeBLL.IsUnique(Convert.ToInt32(txtUserNo.Text)))
                        MessageBox.Show("This user does not exist");
                    else
                    {
                        
                        employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                        employee.Name = txtName.Text;
                        employee.Password = txtPassword.Text;
                        employee.IsAdmin = chAdmin.Checked;
                        employee.Salary = Convert.ToInt32(txtSalary.Text);
                        employee.Surname = txtSurname.Text;
                        employee.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                        employee.PositionID = Convert.ToInt32(cmbPosition.SelectedValue);
                        employee.Address = txtAddres.Text;
                        employee.Birthday = dateTimePicker1.Value;
                        employee.ImagePath = filename;
                        EmployeeBLL.AddEmployee(employee);
                        File.Copy(txtImagePath.Text, @"Images\\" + filename);
                        MessageBox.Show("The Employee was created");
                        txtUserNo.Clear();
                        txtSurname.Clear();
                        txtName.Clear();
                        txtPassword.Clear();
                        txtSalary.Clear();
                        txtSalary.Clear();
                        txtImagePath.Clear();
                        cmbDepartment.SelectedIndex = -1;
                        cmbPosition.DataSource = dto.Posiiton;
                        cmbPosition.SelectedIndex = -1;
                        combofull = true;
                        dateTimePicker1.Value = DateTime.Today;
                        pictureBox1.Image = null;
                        chAdmin.Checked = false;
                    }

                }else
                {
                    DialogResult result = MessageBox.Show("Are you sure,", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (txtImagePath.Text != imagepath)
                        {
                            if (File.Exists(@"Images\\" + detail.ImagePath))
                                File.Delete(@"Images\\" + detail.ImagePath);

                            File.Copy(txtImagePath.Text, @"Images\\" + filename);
                            employee.ImagePath = filename;
                        }else
                            employee.ImagePath = detail.ImagePath;

                        employee.ID = detail.EmployeeID;
                        employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                        employee.Name = txtName.Text;
                        employee.Surname = txtSurname.Text;
                        employee.IsAdmin = chAdmin.Checked;
                        employee.Password = txtPassword.Text;
                        employee.Address = txtAddres.Text;
                        employee.Birthday = dateTimePicker1.Value;
                        employee.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                        employee.PositionID = Convert.ToInt32(cmbPosition.SelectedValue);
                        employee.Salary = Convert.ToInt32(txtSalary.Text);
                        EmployeeBLL.UpdateEmployee(employee);
                        MessageBox.Show("The Employee was updated");
                        this.Close();
                    }
                }

            }
        }
        bool IsUnique = false;
        private void btCheck_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
            {
                MessageBox.Show("You missed the User Number");
            }
            else
            {
                IsUnique = EmployeeBLL.IsUnique(Convert.ToInt32(txtUserNo.Text));
                if(!IsUnique)
                {
                    MessageBox.Show("The User Number already exist");
                }
            }
        }
    }
}

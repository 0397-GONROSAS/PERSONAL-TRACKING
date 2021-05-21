using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using DAL.DTO;

namespace PersonalTracking
{
    public partial class FrmPermission : Form
    {
        public FrmPermission()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TimeSpan PermissionDay;
        public bool isUpdated = false;
        public PermissionDetailDTO detail = new PermissionDetailDTO();
        private void FrmPermission_Load(object sender, EventArgs e)
        {
            txtUserNo.Text = UserStatic.UserNumber.ToString();
            if(isUpdated)
            {
                dpStart.Value = detail.StartDay;
                dpFinish.Value = detail.EndDay;
                txtAmount.Text = detail.PermissionDayAmount.ToString();
                txtExplanation.Text = detail.Explanation;
                txtUserNo.Text = detail.UserNo.ToString();
            }
        }

        private void dpStart_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dpFinish.Value.Date - dpStart.Value.Date;
            txtAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void dpFinish_ValueChanged(object sender, EventArgs e)
        {
            PermissionDay = dpFinish.Value.Date - dpStart.Value.Date;
            txtAmount.Text = PermissionDay.TotalDays.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() == "")
                MessageBox.Show("Please change end or start date");
            else if (Convert.ToInt32(txtAmount.Text) <= 0)
                MessageBox.Show("Permission day must be greater than 0");
            else if (txtExplanation.Text.Trim() == "")
                MessageBox.Show("Explain the permission");
            else
            {
                Permission permission = new Permission();
                if (!isUpdated)
                {  
                    permission.EmployeeID = UserStatic.EmployeeID;
                    permission.PermissionState = 1;
                    permission.PermissionStartDate = dpStart.Value.Date;
                    permission.PermissionEndDate = dpFinish.Value.Date;
                    permission.PermissionDay = Convert.ToInt32(txtAmount.Text);
                    permission.PermissionExplain = txtExplanation.Text;
                    PermissionBLL.AddPermission(permission);
                    MessageBox.Show("Permission was created");
                    permission = new Permission();
                    dpStart.Value = DateTime.Today;
                    dpFinish.Value = DateTime.Today;
                    txtAmount.Clear();
                    txtExplanation.Clear();
                }
               else if(isUpdated)
                {
                    DialogResult result = MessageBox.Show("Do you want to continue?","Warning",MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {                    
                        permission.ID = detail.PermissionID;
                        permission.PermissionExplain = txtExplanation.Text;
                        permission.PermissionStartDate = dpStart.Value;
                        permission.PermissionEndDate = dpFinish.Value;
                        permission.PermissionDay = Convert.ToInt32(txtAmount.Text);
                        PermissionBLL.UpdatePermission(permission);
                        MessageBox.Show("The permission was updated");
                        this.Close();
                    }
                }
            }

        }
    }
}

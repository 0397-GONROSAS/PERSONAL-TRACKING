﻿
namespace PersonalTracking
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPosition = new System.Windows.Forms.Button();
            this.btnSalary = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            this.btnPermission = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Image = global::PersonalTracking.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(426, 402);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(201, 165);
            this.btnExit.TabIndex = 0;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPosition
            // 
            this.btnPosition.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPosition.Image = global::PersonalTracking.Properties.Resources.position;
            this.btnPosition.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPosition.Location = new System.Drawing.Point(548, 215);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(201, 160);
            this.btnPosition.TabIndex = 0;
            this.btnPosition.Text = "Position";
            this.btnPosition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPosition.UseVisualStyleBackColor = false;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalary.Image = global::PersonalTracking.Properties.Resources.salary;
            this.btnSalary.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalary.Location = new System.Drawing.Point(548, 12);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(201, 166);
            this.btnSalary.TabIndex = 0;
            this.btnSalary.Text = "Salary";
            this.btnSalary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalary.UseVisualStyleBackColor = false;
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogOut.Image = global::PersonalTracking.Properties.Resources.logout;
            this.btnLogOut.Location = new System.Drawing.Point(182, 402);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(201, 165);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnDepartment
            // 
            this.btnDepartment.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDepartment.Image = global::PersonalTracking.Properties.Resources.department;
            this.btnDepartment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDepartment.Location = new System.Drawing.Point(289, 215);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(201, 160);
            this.btnDepartment.TabIndex = 0;
            this.btnDepartment.Text = "Department";
            this.btnDepartment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepartment.UseVisualStyleBackColor = false;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // btnTask
            // 
            this.btnTask.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTask.Image = global::PersonalTracking.Properties.Resources.tasks;
            this.btnTask.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTask.Location = new System.Drawing.Point(289, 12);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(201, 166);
            this.btnTask.TabIndex = 0;
            this.btnTask.Text = "Tasks";
            this.btnTask.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTask.UseVisualStyleBackColor = false;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // btnPermission
            // 
            this.btnPermission.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPermission.Image = global::PersonalTracking.Properties.Resources.permission;
            this.btnPermission.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPermission.Location = new System.Drawing.Point(36, 215);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(201, 160);
            this.btnPermission.TabIndex = 0;
            this.btnPermission.Text = "Permission";
            this.btnPermission.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPermission.UseVisualStyleBackColor = false;
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEmployee.Image = global::PersonalTracking.Properties.Resources.employee;
            this.btnEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmployee.Location = new System.Drawing.Point(36, 12);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(201, 166);
            this.btnEmployee.TabIndex = 0;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 579);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPosition);
            this.Controls.Add(this.btnSalary);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnDepartment);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.btnEmployee);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Button btnSalary;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Button btnPosition;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnExit;
    }
}
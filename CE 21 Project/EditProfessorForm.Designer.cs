namespace CE_21_Project
{
    partial class EditProfessorForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.ContactBox = new System.Windows.Forms.TextBox();
            this.DepartmentBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(200, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Personal Information";
            // 
            // AddButton
            // 
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.Location = new System.Drawing.Point(53, 248);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(362, 41);
            this.AddButton.TabIndex = 24;
            this.AddButton.Text = "Save Changes";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddressBox
            // 
            this.AddressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressBox.Location = new System.Drawing.Point(169, 199);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(246, 22);
            this.AddressBox.TabIndex = 23;
            this.AddressBox.TextChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // ContactBox
            // 
            this.ContactBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactBox.Location = new System.Drawing.Point(169, 171);
            this.ContactBox.Name = "ContactBox";
            this.ContactBox.Size = new System.Drawing.Size(246, 22);
            this.ContactBox.TabIndex = 22;
            this.ContactBox.TextChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // DepartmentBox
            // 
            this.DepartmentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentBox.Location = new System.Drawing.Point(169, 145);
            this.DepartmentBox.Name = "DepartmentBox";
            this.DepartmentBox.Size = new System.Drawing.Size(246, 22);
            this.DepartmentBox.TabIndex = 21;
            this.DepartmentBox.TextChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // LastNameBox
            // 
            this.LastNameBox.Enabled = false;
            this.LastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameBox.Location = new System.Drawing.Point(169, 118);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(246, 22);
            this.LastNameBox.TabIndex = 20;
            this.LastNameBox.TextChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Enabled = false;
            this.FirstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameBox.Location = new System.Drawing.Point(169, 92);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(246, 22);
            this.FirstNameBox.TabIndex = 19;
            this.FirstNameBox.TextChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Contact No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "First Name";
            // 
            // ClearButton
            // 
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ClearButton.Location = new System.Drawing.Point(53, 295);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(362, 41);
            this.ClearButton.TabIndex = 13;
            this.ClearButton.Text = "Reset";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // EditProfessorForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 379);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.ContactBox);
            this.Controls.Add(this.DepartmentBox);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearButton);
            this.Name = "EditProfessorForm";
            this.Text = "EditProfessorForm";
            this.Load += new System.EventHandler(this.EditProfessorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button AddButton;
        protected internal System.Windows.Forms.TextBox AddressBox;
        protected internal System.Windows.Forms.TextBox ContactBox;
        protected internal System.Windows.Forms.TextBox DepartmentBox;
        protected internal System.Windows.Forms.TextBox LastNameBox;
        protected internal System.Windows.Forms.TextBox FirstNameBox;
        protected internal System.Windows.Forms.Label label5;
        protected internal System.Windows.Forms.Label label4;
        protected internal System.Windows.Forms.Label label3;
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button ClearButton;

    }
}
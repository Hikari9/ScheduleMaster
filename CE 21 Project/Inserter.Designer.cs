namespace CE_21_Project
{
    partial class Inserter
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
            this.TestButton = new System.Windows.Forms.Button();
            this.first = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.last = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.ComboBox();
            this.from = new System.Windows.Forms.TextBox();
            this.to = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.TextBox();
            this.lab = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.classroom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(38, 382);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(151, 63);
            this.TestButton.TabIndex = 0;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // first
            // 
            this.first.Location = new System.Drawing.Point(117, 290);
            this.first.Name = "first";
            this.first.Size = new System.Drawing.Size(187, 20);
            this.first.TabIndex = 1;
            this.first.Text = "Bryan";
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(38, 31);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(463, 220);
            this.log.TabIndex = 2;
            this.log.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "First name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last name";
            // 
            // last
            // 
            this.last.Location = new System.Drawing.Point(117, 316);
            this.last.Name = "last";
            this.last.Size = new System.Drawing.Size(187, 20);
            this.last.TabIndex = 5;
            this.last.Text = "Lao";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Day";
            // 
            // day
            // 
            this.day.FormattingEnabled = true;
            this.day.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.day.Location = new System.Drawing.Point(352, 299);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(121, 21);
            this.day.TabIndex = 7;
            this.day.Text = "Monday";
            // 
            // from
            // 
            this.from.Location = new System.Drawing.Point(352, 367);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(58, 20);
            this.from.TabIndex = 8;
            this.from.Text = "12:30";
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(438, 367);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(58, 20);
            this.to.TabIndex = 11;
            this.to.Text = "13:30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "to";
            // 
            // department
            // 
            this.department.Location = new System.Drawing.Point(117, 342);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(187, 20);
            this.department.TabIndex = 14;
            this.department.Text = "ECCE";
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Location = new System.Drawing.Point(35, 345);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(62, 13);
            this.lab.TabIndex = 13;
            this.lab.Text = "Department";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Classroom";
            // 
            // classroom
            // 
            this.classroom.Location = new System.Drawing.Point(281, 404);
            this.classroom.Name = "classroom";
            this.classroom.Size = new System.Drawing.Size(121, 20);
            this.classroom.TabIndex = 17;
            this.classroom.Text = "CTC 219";
            // 
            // Inserter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 516);
            this.Controls.Add(this.classroom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.department);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.day);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.last);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.first);
            this.Controls.Add(this.TestButton);
            this.Name = "Inserter";
            this.Text = "Inserter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.TextBox first;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox last;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox day;
        private System.Windows.Forms.TextBox from;
        private System.Windows.Forms.TextBox to;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox department;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox classroom;
    }
}


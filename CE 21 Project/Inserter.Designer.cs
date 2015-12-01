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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inserter));
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(231, 261);
            // 
            // ProfessorList
            // 
            this.ProfessorList.DataSource = ((object)(resources.GetObject("ProfessorList.DataSource")));
            // 
            // RoomList
            // 
            this.RoomList.DataSource = ((object)(resources.GetObject("RoomList.DataSource")));
            // 
            // Inserter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 526);
            this.Name = "Inserter";
            this.Text = "Inserter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
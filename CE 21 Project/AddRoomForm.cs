using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CE_21_Project.Classes;

namespace CE_21_Project
{
    public partial class AddRoomForm : Form
    {

        internal Viewer Host;

        public AddRoomForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (Classroom.Text.Trim() == "")
            {
                MessageBox.Show("Classroom name must not be empty");
                return;
            }
            Room r = Host.sb.GetRoom(Classroom.Text);
            if (r != null)
            {
                MessageBox.Show("Error: Classroom already exists!");
                return;
            }
            //MessageBox.Show("Success!");
            Host.sb.AddRoom(new Room(Classroom.Text));
            Host.RoomList.DataSource = Host.sb.AllRooms.Clone();
            this.Close();
        }
    }
}

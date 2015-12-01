using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleMaster.Classes;

namespace ScheduleMaster
{
    public partial class AddRoomForm : Form
    {

        AllDataViewer Host = Program.adv;

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
            Room r = Program.db.GetRoom(Classroom.Text);
            if (r != null)
            {
                MessageBox.Show("Error: Classroom already exists!");
                return;
            }
            //MessageBox.Show("Success!");
            Room rm = Program.db.AddRoom(new Room(Classroom.Text));
            Host.RoomList.DataSource = Program.db.AllRooms.Clone();
            Host.RenewRoomList();
            Host.RoomList.SelectedItem = rm;
            this.Close();
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            Host.ClassroomBox.Text = "";
        }
    }
}

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
    public partial class EditRoomForm : Form
    {
        internal Viewer Host = null;
        internal Room r = null;
        public EditRoomForm()
        {
            InitializeComponent();
        }

        private void EditRoomForm_Load(object sender, EventArgs e)
        {
            BuildingBox.Text = r.Building;
            RoomBox.Text = r.RoomNumber;
        }

        private void BuildingBox_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = (BuildingBox.Text.Trim() != "");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Unknown error: Room is missing from database!");
            }
            Room find = Host.sb.GetRoom(BuildingBox.Text, RoomBox.Text);
            if (find != null && find != r)
            {
                MessageBox.Show("Error: That classroom already exists!");
                return;
            }
            DialogResult res = MessageBox.Show("Save Room information?", "", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                string oldRoom = r.ToString();
                r.Building = BuildingBox.Text.NormalizeWhiteSpaces();
                r.RoomNumber = RoomBox.Text.NormalizeWhiteSpaces();
                string newRoom = r.ToString();

                Host.RoomList.DataSource = Host.sb.AllRooms.Clone();
                int id = Host.MainData.Columns["Classroom"].Index;
                foreach (DataGridViewRow row in Host.MainData.Rows)
                {
                    if (row.Cells[id].Value.ToString() == oldRoom)
                    {
                        row.Cells[id].Value = newRoom;
                    }
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            BuildingBox.Text = r.Building;
            RoomBox.Text = r.RoomNumber;
        }

        
    }
}

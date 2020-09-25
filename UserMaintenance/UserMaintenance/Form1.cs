using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            lblFullName.Text = Resource1.LastName;
            btnAdd.Text = Resource1.Add;
            btnWIF.Text = Resource1.WriteIntoFile;
            btnDel.Text = Resource1.Delete;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtFullName.Text
            };
            users.Add(u);
        }

        private void btnWIF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() != DialogResult.OK) return;
            
            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var u in users)
                {
                    sw.Write(u.FullName);
                    sw.Write(" - ");
                    sw.Write(u.ID);
                    sw.WriteLine();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem == null) return;
            var deletethis = (User)listUsers.SelectedItem;
            users.Remove(deletethis);
        }
    }
}

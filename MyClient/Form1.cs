using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClient
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hostNameTB_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void portNumberTB_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void usernameTB_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void locationTB_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Program.serverName = hostNameTB.Text;
            Program.username = usernameTB.Text;
            Program.location = locationTB.Text;
            Program.protocol = protocolBox.SelectedItem.ToString();
            if(locationTB.Text == null)
            {
                Program.location = null;
            }
            if(timeoutTB.Text == null)
            {
                Program.timeoutClient = 1000;
            }
            if(usernameTB.Text == null)
            {
                MessageBox.Show("You must enter a username into this field to perform a lookup request, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            int i;
            if(!int.TryParse(timeoutTB.Text, out i) || !int.TryParse(portNumberTB.Text, out i))
            {
                MessageBox.Show("You can only enter numbers into this field, please try again","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int timeoutInt = int.Parse(timeoutTB.Text);
                Program.timeoutClient = timeoutInt;
                int portNumberInt = int.Parse(portNumberTB.Text);
                Program.portNumber = portNumberInt;
                Application.Exit();
            }
            
            
        }

        private void protocolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.debug = true;
            Application.Exit();
        }

        private void timeoutTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

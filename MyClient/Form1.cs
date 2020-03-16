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
            int portNumberInt = int.Parse(portNumberTB.Text);
            Program.portNumber = portNumberInt;
            Program.username = usernameTB.Text;
            Program.location = locationTB.Text;
            Program.protocol = protocolBox.SelectedItem.ToString();

            Application.Exit();
        }

        private void protocolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

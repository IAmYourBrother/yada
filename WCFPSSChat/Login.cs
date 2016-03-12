using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WCFPSSChat
{
    public partial class Login : Form
    {
        //  Form1 mainform;
        string username;
        public Login()
        {
            InitializeComponent();
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = txtUsername.Text;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        
    }
}

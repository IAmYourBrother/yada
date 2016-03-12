using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSSFx;
using PSSLib;
namespace WCFPSSChat
{
    public partial class Form1 : Form, ISubscriber
    {
        string userName;
        IMessenger messenger;
        IPublisher publisher;
        public Form1(string username)
        {
            this.userName = username;
            this.Text = username;
            InitializeComponent();
        }

        public string subscriberName{ get; set; }

        public void receive(PSSFx.Message message)
        {
            throw new NotImplementedException();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            messenger = new Messenger();
            messenger.subscribe(userName,subscriber);
        }

    }
}

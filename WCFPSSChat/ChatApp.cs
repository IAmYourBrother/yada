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
    public partial class ChatApp : Form //, ISubscriber
    {
        string username;
        IMessenger messenger;
        IPublisher publisher;
        public ChatApp()
        {

        }
        public ChatApp(string username)
        {
            this.username = username;
            Text = username;   
            InitializeComponent();
        }

        public string subscriberName
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public void receive(PSSFx.Message message)
        {
            throw new NotImplementedException();
        }

        private void ChatApp_Load(object sender, EventArgs e)
        {
            //messenger = new Messenger();
            //messenger.subscribe(username, this);
        }
    }
}

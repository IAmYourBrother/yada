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


/*
 * To cross connect for the different devices in the appconfig
 */
namespace WcfChat
{
    public partial class ChatApp : Form, ISubscriber
    {
        string username;
        IMessenger messenger;
        IPublisher publisher;
       // private Registration registration;
       // private PSSFactory factory;
        public ChatApp(string username)
        {
            this.username = username;
            this.Text = username;
            messenger = new Messenger();
            messenger.subscribe(subscriberName, this);
            messenger = PSSFactory.getMessenger();
            publisher = PSSFactory.getPublisher();
           // this.registration = reg;
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
            /*if (message.Topic == txtTopic.Text)
            {
                txtMessageList.Text = txtMessageList.Text + "\n" + message.Payload;  
            }*/
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() => this.receive(message)));
            else
            {
                lbxMessages.Items.Add(message.Topic + message.Payload);
                lbxMessages.TopIndex = lbxMessages.Items.Count - 1;
                //lBoxMessage.SelectedIndex = lBoxMessage.Items.Count - 1;
                //lBoxMessage.SelectedIndex = -1;
            }

        }

        private void ChatApp_Load(object sender, EventArgs e)
        {    
        }      

        private void btnSend_Click(object sender, EventArgs e)
        {   
           
            if (!string.IsNullOrEmpty(txtTopic.Text))
            {
                //registration.Topic = txtTopic.Text;
                publisher.publish(new PSSFx.Message(txtTopic.Text, txtPayload.Text));
                txtPayload.Text = "";
            }
            else
            {
                MessageBox.Show("Specify topic", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

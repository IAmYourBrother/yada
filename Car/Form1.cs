using PSSFx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car
{
    public partial class Form1 : Form, ISubscriber
    {
        IMessenger messenger;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            messenger = PSSFactory.getMessenger();
            messenger.subscribe("Car",this);
        }

        public string subscriberName
        {
            get
            {
                return "Car";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void moveCar()
        {
            if(cmd.Equals("Up"))
            {
                this.button1.SetBounds(this.button1.Bounds.X, (this.button1.Bounds.Y - 10), this.button1.Bounds.Width, this.button1.Bounds.Height);
            }
            if (cmd.Equals("Down"))
            {
                this.button1.SetBounds(this.button1.Bounds.X, (this.button1.Bounds.Y + 10), this.button1.Bounds.Width, this.button1.Bounds.Height);
            }
            if (cmd.Equals("Left"))
            {
                this.button1.SetBounds((this.button1.Bounds.X - 10), this.button1.Bounds.Y, this.button1.Bounds.Width, this.button1.Bounds.Height);
            }
            if (cmd.Equals("Right"))
            {
                this.button1.SetBounds((this.button1.Bounds.X + 10), this.button1.Bounds.Y, this.button1.Bounds.Width, this.button1.Bounds.Height);
            }
        }

        string cmd;
        public void receive(PSSFx.Message message)
        {
            cmd = message.Payload.ToString();
            if(this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(moveCar));
                return;
            }
            moveCar();
        }
    }
}

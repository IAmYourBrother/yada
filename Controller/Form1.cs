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

namespace Controller
{
    public partial class Form1 : Form
    {
        IPublisher publisher;
        public Form1()
        {
            InitializeComponent();
            publisher = PSSFactory.getPublisher();
        }

        /*
         * Sends an up string to car
         * 
         * or sends command of command up
         * */

        //--UP--//
        private void button1_Click(object sender, EventArgs e)
        {
            PSSFx.Message message = new PSSFx.Message();
            message.Topic = "Car";
            message.Payload = "Up";
            publisher.publish(message);
        }

        //--RIGHT--//
        private void button3_Click(object sender, EventArgs e)
        {
            PSSFx.Message message = new PSSFx.Message();
            message.Topic = "Car";
            message.Payload = "Right";
            publisher.publish(message);
        }

        //--LEFT--//
        private void button2_Click(object sender, EventArgs e)
        {
            PSSFx.Message message = new PSSFx.Message();
            message.Topic = "Car";
            message.Payload = "Left";
            publisher.publish(message);
        }

        //--DOWN--//
        private void button4_Click(object sender, EventArgs e)
        {
            PSSFx.Message message = new PSSFx.Message();
            message.Topic = "Car";
            message.Payload = "Down";
            publisher.publish(message);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

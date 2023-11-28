using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace WinFormsAlarmApp
{
    public partial class Form1 : Form
    {
        Timer timer01 = new Timer();
        SoundPlayer sp = new SoundPlayer("P:\\gennady_documents\\Coding tools\\VS-projects(C)\\WinFormsAlarmApp\\Alarm.wav");
        bool b = false;

        private string Hour;
        private string Min;
        private string Sec;

        private string HourNow;
        private string MinNow;
        private string SecNow;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            timer01.Interval = 1000;
            timer01.Tick += new EventHandler(timer1_Tick);
            timer01.Start();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (maskedTextBox2.Text == null || label2.Text == null)
            {
                MessageBox.Show("Данные не введены");
            }
            else 
            */
            if (b == false)
            {
                label2.Text = maskedTextBox2.Text;
                timer2.Start();
                maskedTextBox2.Visible = false;
                button1.Text = "Убрать будильник";
                b = true;
            }
            else if (b == true)
            {
                label2.Text = "00:00:00";
                timer2.Stop();
                maskedTextBox2.Visible = true;
                button1.Text = "Завести будильник";
                b = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.Stop();
            button2.Enabled = false;
            maskedTextBox2.Visible = true;
            button1.Text = "Завести будильник";
            b = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            //label1.Text = DateTime.Now.ToString("HH:mm:ss");

            HourNow = DateTime.Now.Hour.ToString("00");
            MinNow = DateTime.Now.Minute.ToString("00");
            SecNow = DateTime.Now.Second.ToString("00");

            //before the truth to set u free я устала пиздец 

            label1.Text = HourNow +":"+ MinNow +":"+ SecNow;

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (label1.Text == label2.Text)
            {
                button2.Enabled = true;
                sp.Play();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();

        }
    }
}

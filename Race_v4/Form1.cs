using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_v4
{
    public partial class Form1 : Form
    {
        Graphics g;
        RaceProcess process;
        public delegate void MyDelegate();
        int count_cars = 4, count_cycle = 1;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            process = new RaceProcess(count_cycle);
            process.l1 = new Accident(Width, Height, 350);
            process.l2 = new Accident(Width, Height, 350);
        }

        private void SF_Click(object sender, EventArgs e)
        {
            process.ClearCars();
            if (SF.Text == "Старт")
            {
                for (int i = 0; i < count_cars; i++)
                    process.AddCar(495, 295 + i * 20, i);
                process.StartRace();
                timer1.Start();
                process.State(true);
                SF.Text = "Стоп";
                label1.Text = "Вперёд!";
            }
            else
            {
                timer1.Stop();
                process.State(false);
                SF.Text = "Старт";
                label1.Text = "";
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Drawing.Draw(e.Graphics, process, count_cars);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

    }
}

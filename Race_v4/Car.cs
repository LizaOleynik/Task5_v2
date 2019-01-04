using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_v4
{
    public delegate void Crash(Car car);
    public class Car
    {
       public event Crash GetCrash;
       public bool crash { get; set; }
       public double crash_speed { get; set; }

        int x, y;
        public int number;
        public int speed;
        int q_x, q_y;
        public int count_cycle;
        
        public int X { get { return x; } set { if (value >= 0) x = value; } }
        public int Y { get { return y; } set { if (value >= 0) y = value; } }

        public Car(int x_, int y_, int n)
        {
            Random rnd = new Random();
            number = n;
            X = x_;
            Y = y_;
            crash_speed = 0.001;
            q_x = -1;
            q_y = 0;
            count_cycle = 0;
        }

        public void Move()
        {
            X += q_x;
            Y += q_y;
            Random rnd = new Random();
            double k = rnd.NextDouble();
            if (k <= crash_speed)
            {
                crash = true;
            }
        }

        public void Left()
        {
            q_x = -1; q_y = 0;
        }

        public void Up()
        {
            q_x = 0; q_y = -1;
        }

        public void Right()
        {
            q_x = 1; q_y = 0;
        }

        public void Down()
        {
            q_x = 0; q_y = 1;
        }

        public void IncCount()
        {
            count_cycle++;
        }


    }
}

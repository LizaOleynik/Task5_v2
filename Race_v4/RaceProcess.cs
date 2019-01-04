using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Race_v4
{
    public class RaceProcess
    {
        public bool state;
        public List<Car> cars;
        public int count_cycle; 
        public Accident l1, l2;

        public RaceProcess(int cycles)
        {
            cars = new List<Car>();
            count_cycle = cycles;
            state = false;
        }

        public void State(bool s)
        {
            state = s;
        }

        public void AddCar(int x, int y, int n)
        {
            cars.Add(new Car(x, y, n));
        }

        public void ClearCars()
        {
            cars.Clear();
        }

        public void StartRace()
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < cars.Count; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Movement));
                threads.Add(t);
                threads[i].Start(cars[i]);
            }

            Thread loader1 = new Thread(new ParameterizedThreadStart(Loader));
            Thread loader2 = new Thread(new ParameterizedThreadStart(Loader));
            loader1.Start(l1);
            loader2.Start(l2);
        }

        void Movement(object obj)
        {
            Car car = (Car)obj;

            while (car.count_cycle < count_cycle)
            {
                if (!car.crash)
                {
                    Cars(car);
                    Thread.Sleep(10);
                }
            }
        }

        void Cars(Car c)
        {
            int i = c.number;
            if (c.X == 545 + i * 20 && c.Y == 295 + i * 20)
                c.Left();
            else if (c.X == 95 - i * 20 && c.Y == 295 + i * 20)
                c.Up();
            else if (c.X == 95 - i * 20 && c.Y == 95 - i * 20)
                c.Right();
            else if (c.X == 545 + i * 20 && c.Y == 95 - i * 20)
                c.Down();
            c.Move();
        }

        private void Loader(object ld)
        {
            Accident l = (Accident)ld;
            while (state)
            {
                cars.ForEach(s =>
                  {
                      if (s.crash && Monitor.TryEnter(s))
                      {
                          lock (s)
                          {
                              l.Crash = true;
                              int x = Math.Abs(l.X - s.X);
                              int y = Math.Abs(l.Y - s.Y);

                              while (Math.Abs(l.X - s.X) >= 0.5 || Math.Abs(l.Y - s.Y) >= 0.5)
                              {
                                  l.Move(s.X, s.Y);
                                  Thread.Sleep(10);
                              }
                              Thread.Sleep(500);
                              s.crash = false;
                          }
                      }
                  });
                if (l.Y < l.startPointY)
                {
                    l.Move(l.X, 350);
                    Thread.Sleep(10);
                }
                else
                {
                    l.Crash = false;
                    Thread.Sleep(50);
                }
            }
        }
        }

}

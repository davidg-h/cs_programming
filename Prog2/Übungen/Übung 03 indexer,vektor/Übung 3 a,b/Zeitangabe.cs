using System;
namespace Übung_3
{
    class Zeitangabe
    {
        int days, hours, min, sec;

        public int Days
        {
            get { return days; }
            set
            {
                days = value;
            }
        }

        public int Hours
        {
            get { return hours; }
            set
            {
                hours = value;
            }
        }

        public int Min
        {
            get { return min; }
            set
            {
                min = value;
            }
        }

        public int Sec
        {
            get { return sec; }
            set
            {
                sec = value;
            }
        }

        public Zeitangabe(int days, int h, int min, int sec)
        {
            Days = days;
            Hours = h;
            Min = min;
            Sec = sec;
        }

        public Zeitangabe(int inSec)
        {
            sec = inSec;
        }

        public int TimeInSeconds()
        {
            return Days * 24 * 60 * 60 + Hours * 60 * 60 + Min * 60 + Sec;
        }

        public void Print()
        {
            Console.WriteLine($"Tage: {days}");
            Console.WriteLine($"Stunden: {hours}");
            Console.WriteLine($"Minuten: {min}");
            Console.WriteLine($"Sekunden: {sec}");
        }

        public void NormalTime(int s)
        {
            Days = s / 86400;
            Hours = s % 86400 / 3600;
            Min = s % 86400 % 3600 / 60;
            sec = s % 86400 % 3600 % 60;
        }
        public static Zeitangabe operator +(Zeitangabe one, Zeitangabe two)
        {
            int  z = one.TimeInSeconds() + two.TimeInSeconds();
            Zeitangabe zeit = new Zeitangabe(z);
            zeit.NormalTime(z);
            return zeit;
        }

        public static Zeitangabe operator -(Zeitangabe one, Zeitangabe two)
        {
            int z = one.TimeInSeconds() - two.TimeInSeconds();
            Zeitangabe zeit = new Zeitangabe(z);
            zeit.NormalTime(z);
            return zeit;
        }

        public static Zeitangabe operator ++(Zeitangabe one)
        {
            int z = one.TimeInSeconds() +1;
            Zeitangabe zeit = new Zeitangabe(z);
            zeit.NormalTime(z);
            return zeit;
        }

        public static Zeitangabe operator --(Zeitangabe one)
        {
            int z = one.TimeInSeconds() - 1;
            Zeitangabe zeit = new Zeitangabe(z);
            zeit.NormalTime(z);
            return zeit;
        }
    }
}

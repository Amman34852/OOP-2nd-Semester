using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_3
{
    class clockType
    {
        int hours;
        int minutes;
        int seconds;
        public clockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public clockType(int h)
        {
            hours = h;
        }
        public clockType(int h,int m)
        {
            minutes = m;
        }
        public clockType(int h , int m , int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        public void incrementHour()
        {
            hours++;
        }
        public void incrementMinutes()
        {
            minutes++;
        }
        public void incrementSeconds()
        {
            seconds++;
        }
        public void printTime()
        {
            Console.WriteLine(hours + " " + minutes + " " + seconds);
        }
        public int elapsedTime(int h , int m, int s)
        {
            int elapsedTime = (h*3600)+(m*60)+(s);
            return elapsedTime;
        }
        public int remianingTime(int h,int m , int s)
        {
            int remainingTime = 86400 - elapsedTime(h, m, s);
            return remainingTime;
        }
        public string formatTime(int h, int m ,int s)
        {
            return $"{h:D2}:{m:D2}:{s:D2}";
        }
        public bool isEqual(int h, int m , int s)
        {
            if(hours ==h && minutes ==m && seconds ==s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int hr , min , sec ;
            clockType empty_time = new clockType();
            empty_time.printTime();
            clockType hour_time = new clockType(3);
            hour_time.printTime();
            clockType minute_time = new clockType(3,4);
            minute_time.printTime();
            clockType second_time = new clockType(3, 4,5);
            second_time.printTime();
            second_time.incrementHour();
            second_time.printTime();
            second_time.incrementMinutes();
            second_time.printTime();
            second_time.incrementSeconds();
            second_time.printTime();
            Console.WriteLine("Enter current hour : ");
            hr = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter curent minutes : ");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter current second : ");
            sec = int.Parse(Console.ReadLine());
            Console.WriteLine("Elapsed time is : " + second_time.elapsedTime(hr,min,sec));
            Console.WriteLine("Remaing Time is : " + second_time.remianingTime(hr,min,sec));
            Console.WriteLine("Time in correct format : "+second_time.formatTime(hr,min,sec));
            Console.ReadKey();
        }
    }
}

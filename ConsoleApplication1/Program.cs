﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {


        static void Main(string[] args)
        {
            int baseValue = 90;
            int height = 336;
            /*  int initialValue = 256;
              string startString = "256,336,51532,6,0,B";
              string endString = ",1,206640";  */
            string output = null;
            string points = null;
            string aaaa;
            int offset;
            int pointA;
            int pointB;
            string stringA;
            string stringB;

            string object1;   //see getfruit method for object1 info
            int startHeight = 0;
            int endHeight = height + 10 + 60; //60 for playfield compensation
            string scaleCommand;
            StringBuilder OSBOutput = new StringBuilder();
            string moveCommand;
            int duration = 800;
            float quarterBeat = 88.23529411764f;
            int timeOffset = 51532;
            float currentTime = timeOffset;

            while (true)
            {
                Console.WriteLine("initial x value");
                int lastpoint = int.Parse(Console.ReadLine());
                Console.WriteLine("offset");

                do
                {
                    aaaa = Console.ReadLine();
                    if (aaaa != "f")
                    {
                        try
                        {
                            offset = int.Parse(aaaa);
                            pointB = lastpoint + offset;

                            /*  roundsUp = bool.Parse(((baseValue + offset) % 2).ToString());
                              if (roundsUp) {   } */
                            //just use an even offset and basevalue
                            pointA = lastpoint + (baseValue + offset) / 2;


                            stringA = '|' + pointA.ToString() + ':' + height + '|' + pointA + ':' + height; //string.format u retard??
                            stringB = '|' + pointB.ToString() + ':' + height + '|' + pointB + ':' + height;

                            lastpoint = pointB;
                            points += stringA + stringB;



                            currentTime += quarterBeat;

                            object1 = GetFruit();
                            scaleCommand = string.Format(" S,0,{0},,0.4318906", Math.Round(currentTime));
                            moveCommand = string.Format(" M,0,{0},{1},{2},{3},{2},{4}", Math.Round(currentTime - duration), Math.Round(currentTime), (pointB + 60), startHeight, endHeight);
                            OSBOutput.AppendLine(object1);
                            OSBOutput.AppendLine(moveCommand);
                            OSBOutput.AppendLine(scaleCommand);

                            Console.WriteLine("x = " + pointB + ", t = " + currentTime);

                        }
                        catch
                        { Console.WriteLine("invalid number??"); }


                    }
                    else { break; }

                } while (aaaa != "f");
                //output = startString + points + endString;
                output = points;
                Console.WriteLine(output);
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\slider.txt", output);

                Console.WriteLine(OSBOutput);
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\story.txt", OSBOutput.ToString());

                Console.Read();
                Console.Read();
            }
        }

        public static string GetFruit()
        {
            Random rnd = new Random();
            int fruitID = rnd.Next(0, 4);
            string fruitName;
            switch (fruitID)
            {
                default:
                case 0: fruitName = "fruit-apple.png";
                    break;
                case 1: fruitName = "fruit-bananas.png";
                    break;
                case 2:
                    fruitName = "fruit-grapes.png";
                    break;
                case 3:
                    fruitName = "fruit-orange.png";
                    break;
                case 4:
                    fruitName = "fruit-pear.png";
                    break;
            }

            string object1 = string.Format("Sprite,Foreground,Centre,\"{0}\",320,240", fruitName);
            return object1;
        }
    }
}

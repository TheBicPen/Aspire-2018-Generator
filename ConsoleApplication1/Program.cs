using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// this program is trash and so am i
        /// </summary>
        /// <param name="args"></param>

        static Random rnd;

        static void Main(string[] args)
        {
            rnd = new Random();

            bool fileMode;
            if (args.Length != 0)
            {  fileMode = true; }
            else {  fileMode = false; }

                //static variables
                int baseValue = 90;
            int height = 336;
            /*  int initialValue = 256;
              string startString = "256,336,51532,6,0,B";
              string endString = ",1,206640";  */

            //i'm tired, fk this

            const string storyStartString = @"[Events]
//Background and Video events
//Storyboard Layer 0 (Background)
Sprite,Background,Centre,""Black.png"",320,240
 M,0,-702,254146,320,404.01
Sprite,Background,Centre,""area.png"",320,240
 M,0,-702,254146,320,404.01,320,404.01
 V,0,50826,,4.170305,0.3367526
//Storyboard Layer 1 (Fail)
//Storyboard Layer 2 (Pass)
//Storyboard Layer 3 (Foreground)
";
            const string storyEndString = @"//Storyboard Sound Samples";
            const string mapStartString = @"osu file format v14

[General]
AudioFilename: audio.mp3
AudioLeadIn: 0
PreviewTime: -1
Countdown: 1
SampleSet: Soft
StackLeniency: 0.5
Mode: 0
LetterboxInBreaks: 0
SkinPreference:Aspire
WidescreenStoryboard: 0

[Editor]
Bookmarks: 28238,34591,40944,51532,87532
DistanceSpacing: 1.3
BeatDivisor: 4
GridSize: 16
TimelineZoom: 0.8000001

[Metadata]
Title:Acid Rain
TitleUnicode:Acid Rain
Artist:Culprate
ArtistUnicode:Culprate
Creator:The Bic Pen
Version:Catch the Beat
Source:
Tags:see has notes txt generated program script aspire catch the beat CtB 
BeatmapID:0
BeatmapSetID:-1

[Difficulty]
HPDrainRate:1.7
CircleSize:6.6 
OverallDifficulty:0
ApproachRate:0
SliderMultiplier:3.6
SliderTickRate:4

[Events]
//Background and Video events
0,0,""BG.jpg"",0,0
//Break Periods
//Storyboard Layer 0 (Background)
//Storyboard Layer 1 (Fail)
//Storyboard Layer 2 (Pass)
//Storyboard Layer 3 (Foreground)
//Storyboard Sound Samples

[TimingPoints]
1415,352.941176470588,4,2,0,100,1,0
1415,-100,4,2,0,5,0,0
181439,-100,4,2,0,5,0,0
182145,-100,4,2,0,5,0,0
186539,-100,4,2,0,5,0,0
187612,-100,4,2,0,5,0,0
188214,-100,4,2,0,5,0,0
188851,-100,4,2,0,5,0,0
189203,-100,4,2,0,5,0,0
190786,-100,4,2,0,5,0,0
192021,-100,4,2,0,5,0,0
197829,-100,4,2,0,5,0,0
199064,-100,4,2,0,5,0,0
200667,-100,4,2,0,5,0,0
203314,-100,4,2,0,5,0,0
208247,-100,4,2,0,5,0,0
208952,-100,4,2,0,5,0,0
220942,-100,4,2,0,5,0,0
221304,-100,4,2,0,5,0,0
221656,-100,4,2,0,5,0,0


[HitObjects]
256,336,51532,6,0,B"; 
            string mapEndString = @",1,206640";

            int lastPoint = 256;

            string aaaa = null;
            int offset;
            int pointA;
            int pointB;
            string stringA;
            string stringB;
            string errors = "";
            int counter = 0;

            string object1;   //see getfruit method for object1 info
            int startHeight = 0;
            int endHeight = height - 10 + 60; //60 for playfield compensation
            string scaleCommand;

            string moveCommand;
            int approachTime = 800;
            double quarterBeat = 88.23529411764f;
            int timeOffset = 51532;
            double currentTime = timeOffset;
            //  bool directionX;

            string storyFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\story.txt";
            string sliderFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\slider.txt";

            while (true)
            {

                string output = null;
                string points = null;

                StringBuilder OSBOutput = new StringBuilder();

                /*
                Console.WriteLine("move along x or y?"); //always use x
                string str = Console.ReadLine();
                if(str == "x")
                { directionX = true; }
                else if(str == "y")
                { directionX = false; }
                else
                {
                    Console.WriteLine("nope");
                    break;
                } */

                StreamReader sr = null;
                string line = null;
                if (fileMode)
                {
                    sr = new StreamReader(args[0]);
                    lastPoint = int.Parse(sr.ReadLine());
                    currentTime = double.Parse(sr.ReadLine());
                }
                else
                {
                    Console.WriteLine("initial x value (blank for default)");
                    string str1 = Console.ReadLine();
                    if (str1 != "")
                    { lastPoint = int.Parse(str1); }
                    Console.WriteLine("x value = " + lastPoint);

                    Console.WriteLine("initial time (blank for default)");
                    string str = Console.ReadLine();
                    if (str != "")
                    { currentTime = double.Parse(str); }
                    Console.WriteLine("time = " + currentTime);

                    /*
                    Console.WriteLine("initial y value (or blank for default)");
                    int lastPoint = int.Parse(Console.ReadLine());
                    if (Console.ReadLine() != "")
                    {
                        initialYCoord = Co
                    }
                    */
                    Console.WriteLine("offset and approach time");
                }

                do
                {
                    if (fileMode)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            aaaa = line;
                        }
                        else
                        {
                            break;
                        }
                    }

                    else
                    {
                        aaaa = Console.ReadLine();
                    }

                    if (aaaa != "f")
                    {
                        try
                        {
                            string[] data = aaaa.Split(new char[0]);
                            offset = int.Parse(data[0]);
                            approachTime = int.Parse(data[1]);
                            pointB = lastPoint + offset;
                            counter++;

                            /*  roundsUp = bool.Parse(((baseValue + offset) % 2).ToString());
                              if (roundsUp) {   } */
                            //just use an even offset and basevalue. problem solved.
                            pointA = (int)(Math.Round(lastPoint + (baseValue + offset) / 2d));
                            int distanceTravelled = Math.Abs(pointA - lastPoint) + Math.Abs(pointB - pointA);

                        /*    if (directionX)
                            { */
                                stringA = string.Format("|{0}:{1}|{0}:{1}", pointA, height);
                                stringB = string.Format("|{0}:{1}|{0}:{1}", pointB, height);
                         /*   }
                            else if (!directionX)
                            {
                                stringA = string.Format("|{1}:{0}|{1}:{0}", pointA, initialYCoord);
                                stringB = string.Format("|{1}:{0}|{1}:{0}", pointB, initialYCoord);
                            }
                            else { break; }   */
                            

                            /*
                            stringA = '|' + pointA.ToString() + ':' + height + '|' + pointA + ':' + height; //string.format u retard??
                            stringB = '|' + pointB.ToString() + ':' + height + '|' + pointB + ':' + height;
                            */

                            lastPoint = pointB;
                            points += stringA + stringB;

                            currentTime += quarterBeat;

                            object1 = GetFruit(int.Parse(data[2]));
                            scaleCommand = string.Format(" S,0,{0},,0.43", Math.Round(currentTime, MidpointRounding.ToEven)); //I thought the rounding problem occurred here, but it was actually in pointA, hence the excessive rounding
                            moveCommand = string.Format(" M,0,{0},{1},{2},{3},{2},{4}", Math.Round(currentTime - approachTime, MidpointRounding.ToEven), Math.Round(currentTime, MidpointRounding.ToEven), (pointB + 64), startHeight, endHeight); //64 for the 128px images
                            OSBOutput.AppendLine(object1);
                            OSBOutput.AppendLine(moveCommand);
                            OSBOutput.AppendLine(scaleCommand);

                        /*    if (directionX)
                            { */Console.WriteLine(string.Format("obj = {5} x = {0}, dx = {4} t = {1}, AR = {2}, dx Total = {3}", pointB, currentTime, approachTime, distanceTravelled, offset, counter)); /*}
                            else
                            { Console.WriteLine("y = " + pointB + ", t = " + currentTime); }  */
                            if (pointB > 512 || pointB < 0)
                            { errors += "Error: obj" + counter + " x=" + pointB + Environment.NewLine; }
                        }
                        catch
                        { Console.WriteLine("invalid number??"); }


                    }
                    else { break; }

                } while (aaaa != "f");
                //output = startString + points + endString;


                Console.WriteLine(output);
                Console.WriteLine(errors);
                if (!fileMode)
                {
                    output = Environment.NewLine + points;
                    OSBOutput.Append(Environment.NewLine);
                    OSBOutput.Append(Environment.NewLine);
                    File.AppendAllText(sliderFile, output);
                    File.AppendAllText(storyFile, OSBOutput.ToString());
                }
                else
                {/*
                    StreamReader mapReader = new StreamReader(args[1]);
                    StreamReader storyReader = new StreamReader(args[2]);
                    do
                    {
                        string str = mapReader.ReadLine();

                        if (str != @"[HitObjects]")
                        { mapStartString += str; }
                        else
                        {
                            mapStartString += str;
                            do
                            {
                                str = mapReader.Read().ToString();
                                if (str != "B")
                                { mapStartString += str; }
                                else
                                {
                                    mapStartString += str;
                                    break;
                                }

                            } while (true);
                            break;
                        }
                    } while (true);
                    */
                    output = mapStartString + points + mapEndString;
                    OSBOutput.Insert(0, storyStartString);
                    OSBOutput.Append(storyEndString);
                    //  File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\slider.txt", output);
                    //  File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\story.txt", OSBOutput.ToString());
                    File.WriteAllText(args[1], output);
                    File.WriteAllText(args[2], OSBOutput.ToString());
                    sr.Dispose();
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine(OSBOutput);
                

                Console.WriteLine(string.Format("output written to files {0} and {1}", sliderFile, storyFile));
                Console.ReadLine();
            }
        }

        public static string GetFruit(int colour)
        {
            
            int fruitID = rnd.Next(0, 4);
            string fruitName;
            switch (fruitID)
            {
                default:
                case 0: fruitName = "fruit-apple" + colour + ".png";
                    break;
                case 1: fruitName = "fruit-bananas" + colour + ".png";
                    break;
                case 2:
                    fruitName = "fruit-grapes" + colour + ".png";
                    break;
                case 3:
                    fruitName = "fruit-orange" + colour + ".png";
                    break;
                case 4:
                    fruitName = "fruit-pear" + colour + ".png";
                    break;
            }

            string object1 = string.Format("Sprite,Foreground,Centre,\"{0}\",320,240", fruitName);
            return object1;
        }
    }
}

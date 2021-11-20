using MarsRover.Model;
using MarsRover.Services;
using System;
using System.Linq;


namespace MarsRover
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cordinate cordinate = new Cordinate();
            Position position = new Position();


            var xyMaxValue = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            cordinate.xMaxValue = xyMaxValue[0];
            cordinate.yMaxValue = xyMaxValue[1];

            //one 
            var startOne = Console.ReadLine().Split(' ');
            var startOneRunning = Console.ReadLine();

            cordinate.xValue = Convert.ToInt32(startOne[0]);
            cordinate.yValue = Convert.ToInt32(startOne[1]);
            cordinate.state = (Direction)Enum.Parse(typeof(Direction), startOne[2]);


            position.Start(cordinate, startOneRunning);

            //two
            var startTwo= Console.ReadLine().Split(' ');
            var startTwoRunning = Console.ReadLine();
            
            cordinate.xValue = Convert.ToInt32(startTwo[0]);
            cordinate.yValue = Convert.ToInt32(startTwo[1]);
            cordinate.state = (Direction)Enum.Parse(typeof(Direction), startTwo[2]);

            position.Start(cordinate, startTwoRunning);









        }
    }
}

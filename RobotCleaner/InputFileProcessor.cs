using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace RobotCleaner
{
  public class InputFileProcessor
  {
    private string filePath;
    private IRobot robot;

    public InputFileProcessor(string path, IRobot r)
    {
      filePath = path;
      robot = r;
    }

    public void process()
    {
      using (StreamReader sr = File.OpenText(filePath))
      {
        int numOfCommands = int.Parse(sr.ReadLine());
        processInitialPositionString(sr.ReadLine());
        for (int i = 0; i < numOfCommands; i++)
        {
          processMovementString(sr.ReadLine());
        }
      }
    }

    private void processInitialPositionString(String str)
    {
      int[] numbers = str.Split().Select(s => int.Parse(s)).ToArray();
      robot.Initialize(new Point(numbers[0], numbers[1]));
    }

    private void processMovementString(string str)
    {
      string[] strItems = str.Split().ToArray();
      string directionStr = strItems[0];
      int numOfSteps = int.Parse(strItems[1]);

      MoveDirection direction;
      Enum.TryParse(directionStr, out direction);

      robot.Move(direction, numOfSteps);
    }
  }
}
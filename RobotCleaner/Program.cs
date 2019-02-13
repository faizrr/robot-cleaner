using System;
using System.Drawing;
using System.IO.Abstractions;


namespace RobotCleaner
{
  class Program
  {
    static void Main(string[] args)
    {
      Robot robot = new Robot();

      InputFileProcessor processor = new InputFileProcessor("./input.txt", robot);
      processor.process();

      CleanedPlacesService service = new CleanedPlacesService(robot);
      int result = service.Calculate();

      Console.WriteLine(result);
    }
  }
}

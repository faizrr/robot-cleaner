using Xunit;
using RobotCleaner;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace RobotCleaner.Tests
{
  public class Robot_initialize
  {
    Robot robot;
    public Robot_initialize()
    {
      robot = new Robot();
    }

    [Fact]
    public void initializesPathHistoryWithRightPoint()
    {
      var p = new Point(12, 34);
      robot.Initialize(p);

      Assert.Equal(robot.PointsHistory[0], p);
    }
  }
}
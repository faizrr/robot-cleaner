using Xunit;
using RobotCleaner;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace RobotCleaner.Tests
{
  public class Robot_move
  {
    Robot robot;
    public Robot_move()
    {
      robot = new Robot();
      robot.Initialize(new Point(0, 0));
    }

    [Fact]
    public void makesRightHistoryWithEDirection()
    {
      robot.Move(MoveDirection.E, 3);
      var expected = new List<Point> {
          new Point(0, 0),
          new Point(1, 0),
          new Point(2, 0),
          new Point(3, 0)
      };
      Assert.Equal(expected, robot.PointsHistory);
    }

    [Fact]
    public void makesRightHistoryWithWDirection()
    {
      robot.Move(MoveDirection.W, 3);
      var expected = new List<Point> {
          new Point(0, 0),
          new Point(-1, 0),
          new Point(-2, 0),
          new Point(-3, 0)
      };
      Assert.Equal(expected, robot.PointsHistory);
    }

    [Fact]
    public void makesRightHistoryWithSDirection()
    {
      robot.Move(MoveDirection.S, 3);
      var expected = new List<Point> {
          new Point(0, 0),
          new Point(0, -1),
          new Point(0, -2),
          new Point(0, -3)
      };
      Assert.Equal(expected, robot.PointsHistory);
    }

    [Fact]
    public void makesRightHistoryWithNDirection()
    {
      robot.Move(MoveDirection.N, 3);
      var expected = new List<Point> {
          new Point(0, 0),
          new Point(0, 1),
          new Point(0, 2),
          new Point(0, 3)
      };
      Assert.Equal(expected, robot.PointsHistory);
    }
  }
}
using System;
using System.Drawing;
using System.Collections.Generic;

namespace RobotCleaner
{
  public interface IRobot
  {
    List<Point> PointsHistory { get; }
    void Initialize(Point p);
    void Move(MoveDirection direction, int numOfSteps);
  }

  public class Robot : IRobot
  {
    public List<Point> PointsHistory { get; }

    public Robot()
    {
      PointsHistory = new List<Point>();
    }

    public void Initialize(Point p)
    {
      PointsHistory.Add(p);
    }

    public void Move(MoveDirection direction, int numOfSteps)
    {
      for (int i = 0; i < numOfSteps; i++)
      {
        PointsHistory.Add(getNextPoint(direction));
      }
    }

    private Point getNextPoint(MoveDirection direction)
    {
      Point lastPoint = PointsHistory[PointsHistory.Count - 1];

      switch (direction)
      {
        case MoveDirection.E:
          return new Point(lastPoint.X + 1, lastPoint.Y);
        case MoveDirection.W:
          return new Point(lastPoint.X - 1, lastPoint.Y);
        case MoveDirection.N:
          return new Point(lastPoint.X, lastPoint.Y + 1);
        case MoveDirection.S:
          return new Point(lastPoint.X, lastPoint.Y - 1);
        default:
          return lastPoint;
      }
    }
  }
}

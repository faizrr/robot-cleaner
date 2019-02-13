using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner
{
  public class CleanedPlacesService
  {
    private IRobot robot;

    public CleanedPlacesService(IRobot _robot)
    {
      robot = _robot;
    }

    public int Calculate()
    {
      List<Point> uniquePoints = robot.PointsHistory.Distinct().ToList();
      return uniquePoints.Count;
    }
  }
}

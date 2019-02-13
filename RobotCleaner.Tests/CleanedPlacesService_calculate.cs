using System;
using Xunit;
using RobotCleaner;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using Moq;

namespace RobotCleaner.Tests
{
  public class CleanedPlacesService_calculate
  {
    private Mock<IRobot> mock;
    private CleanedPlacesService service;

    public CleanedPlacesService_calculate()
    {
      mock = new Mock<IRobot>();
      service = new CleanedPlacesService(mock.Object);
    }

    [Fact]
    public void ReturnsNumberOfUniquePlaces()
    {
      var list = new List<Point> {
        new Point(0, 0),
        new Point(1, 0),
        new Point(2, 0),
        new Point(1, 0)
      };
      mock.SetupGet(m => m.PointsHistory).Returns(list);

      Assert.Equal(service.Calculate(), 3);
    }
  }
}

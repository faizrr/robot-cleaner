using System;
using Xunit;
using RobotCleaner;
using System.Drawing;
using System.IO;
using Moq;

namespace RobotCleaner.Tests
{
  public class InputFileProcessor_input1
  {
    private readonly InputFileProcessor processor;
    private Mock<IRobot> mock;

    public InputFileProcessor_input1()
    {
      mock = new Mock<IRobot>();
      processor = new InputFileProcessor("./fixtures/input1.txt", mock.Object);
    }

    [Fact]
    public void InitializesWithInitialPosition()
    {
      processor.process();
      mock.Verify(r => r.Initialize(new Point(10, 22)), Times.Once());
    }

    [Fact]
    public void MovedWithMoveStringsInRightOrder()
    {
      var mock = new Mock<IRobot>(MockBehavior.Strict);
      mock.Setup(r => r.Initialize(new Point(10, 22)));

      var processor = new InputFileProcessor("./fixtures/input1.txt", mock.Object);

      var seq = new MockSequence();
      mock.InSequence(seq).Setup(m => m.Move(MoveDirection.E, 2));
      mock.InSequence(seq).Setup(m => m.Move(MoveDirection.N, 1));

      processor.process();
    }
  }
}

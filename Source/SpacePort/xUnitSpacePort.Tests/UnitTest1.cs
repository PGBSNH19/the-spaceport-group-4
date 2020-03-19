using System;
using Xunit;
using SpacePort;
using System.Collections.Generic;

namespace xUnitSpacePort.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Spaceport spaceport = new Spaceport();

            //Act


            //Assert
            Assert.NotNull(spaceport);
        }
    }
}

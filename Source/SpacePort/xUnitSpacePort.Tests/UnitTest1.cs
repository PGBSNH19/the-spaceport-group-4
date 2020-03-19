using System;
using Xunit;
using SpacePort;
using System.Collections.Generic;

namespace xUnitSpacePort.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateSpacePortClass()
        {
            //Arrange
            Spaceport spaceport = new Spaceport();

            //Act

            //Assert
            Assert.NotNull(spaceport);
        }

        [Fact]
        public void CreatPortClass()
        {
            //Arrange
            Port port = new Port();
            //Act

            //Assert
            Assert.NotNull(port);
        }

        [Fact]
        public void CreatMenuClass()
        {
            //Arrange
            Menu menu = new Menu();
            //Act

            //Assert
            Assert.NotNull(menu);
        }


    }
}

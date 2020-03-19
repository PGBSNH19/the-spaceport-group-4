using SpacePort;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest.Test
{
    public class UnitTest1
    {
        [Fact]
        public void CreateSpacePort()
        {
            //Arrange
            Spaceport spaceport = new Spaceport();

            //Act
            Dictionary<string, int> ShipTypes = spaceport.ShipTypes;
            
            //Assert
            Assert.NotNull(spaceport);
        }

        [Fact]
        public void CreatMenu()
        {
            //Arrange
            Menu menu = new Menu();

            //Act
            string SignIn = menu.SignIn;
            menu.DisplayMenu();
            menu.DisplayShipTypes();
            menu.CustomerSignIn();

            //Assert
            Assert.NotNull(menu);
        }

        [Fact]
        public void CreateValidate()
        {
            //Arrage
            ValidateCustomer v = new ValidateCustomer();
            string name = v.Name;
            //Act
            //Assert
            Assert.NotNull(v);
        }


    }
}

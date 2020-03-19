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

            Dictionary<string, int> shipTypes = spaceport.ShipTypes;

            //Act
            //Assert
            Assert.NotNull(spaceport);
        }

        [Fact]
        public void CreateMenu()
        {
            //Arrange
            Menu menu = new Menu();

            string SignIn = menu.SignIn;
            menu.DisplayMenu();
            menu.DisplayShipTypes();
            menu.CustomerSignIn();
            //Act
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

        [Fact]
        public void CreateTicket()
        {
            //Arrange
            Ticket ticket = new Ticket();

            int ticketID = ticket.TicketID;
            string shipSize = ticket.ShipSize;
            DateTime timeOfArrival = ticket.TimeOfArrival;
            DateTime timeOfDepature = ticket.TimeOfDepature;
            //Act
            //Assert
            Assert.NotNull(ticket);
        }

        [Fact]
        public void CreateReceipt()
        {
            //Arrange
            Receipt receipt = new Receipt();

            int receiptID = receipt.ReceiptID;
            int ticketID = receipt.TicketID;
            int totalPrice = receipt.TotalPrice;

            //Act
            //Assert
            Assert.NotNull(receipt);
        }
    }
}

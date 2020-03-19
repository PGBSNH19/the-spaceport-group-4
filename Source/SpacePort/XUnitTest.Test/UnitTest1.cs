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
            Dictionary<string, int> shipTypes = spaceport.ShipTypes;
            
            //Assert
            Assert.NotNull(spaceport);
        }

        [Fact]
        public void CreateMenu()
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

        [Fact]
        public void CreateTicket()
        {
            //Arrange
            Ticket ticket = new Ticket();

            //Act
            int ticketID = ticket.TicketID;
            string shipSize = ticket.ShipSize;
            DateTime timeOfArrival = ticket.TimeOfArrival;
            DateTime timeOfDepature = ticket.TimeOfDepature;

            //Assert
            Assert.NotNull(ticket);
        }

        [Fact]
        public void CreateReceipt()
        {
            //Arrange
            Receipt receipt = new Receipt();

            //Act
            int receiptID = receipt.ReceiptID;
            int ticketID = receipt.TicketID;
            int totalPrice = receipt.TotalPrice;

            //Assert
            Assert.NotNull(receipt);
        }
    }
}

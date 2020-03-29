using RestSharp;
using SpacePort;
using SpacePort.Models;
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
            //Assert
            Assert.NotNull(spaceport);
        }

        [Fact]
        public void CreateMenu()
        {
            Menu.Display();

            Menu.TravelerSignIn();
        }

        [Fact]
        public void CreateTicket()
        {
            //Arrange
            Ticket ticket = new Ticket();

            int ticketID = ticket.TicketID;
            DateTime timeOfArrival = ticket.DateTimeOfArrival;
            DateTime timeOfDepature = ticket.DateTimeOfDepature;
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

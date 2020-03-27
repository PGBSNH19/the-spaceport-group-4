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

            Dictionary<string, int> shipTypes = spaceport.ShipTypes;

            //Act
            //Assert
            Assert.NotNull(spaceport);
        }

        [Fact]
        public void CreateMenu()
        {
            //Arrange
           // Menu m;

            string SignIn = Menu.CustomerName;
            Menu.DisplayMenu();
            Menu.DisplayCustomerShips();
            Menu.CustomerSignIn();

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

            int ticketID = ticket.ID;
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

            int receiptID = receipt.ID;
            int ticketID = receipt.TicketID;
            int totalPrice = receipt.TotalPrice;

            //Act
            //Assert
            Assert.NotNull(receipt);
        }

        [Fact]
        public void CreatePeopleAPIResponse()
        {
            //Arrange
            Traveler people = new Traveler();

            string name = people.Name;

            //Act
            //Assert
            Assert.NotNull(people);


        }

    }
}

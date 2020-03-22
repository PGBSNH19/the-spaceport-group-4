using RestSharp;
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
            Menu m;

            string SignIn = Menu.SignIn;
            Menu.DisplayMenu();
            Menu.DisplayShipTypes();
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

    

 //       	"name": "Luke Skywalker",
	//"height": "172",
	//"mass": "77",
	//"hair_color": "blond",
	//"skin_color": "fair",
	//"eye_color": "blue",
	//"birth_year": "19BBY",
	//"gender": "male",
	//"homeworld": "https://swapi.co/api/planets/1/",
	//"films": [
	//	"https://swapi.co/api/films/2/",
	//	"https://swapi.co/api/films/6/",
	//	"https://swapi.co/api/films/3/",
	//	"https://swapi.co/api/films/1/",
	//	"https://swapi.co/api/films/7/"
	//],
	//"species": [
	//	"https://swapi.co/api/species/1/"
	//],
	//"vehicles": [
	//	"https://swapi.co/api/vehicles/14/",
	//	"https://swapi.co/api/vehicles/30/"
	//],
	//"starships": [
	//	"https://swapi.co/api/starships/12/",
	//	"https://swapi.co/api/starships/22/"
	//],
	//"created": "2014-12-09T13:50:51.644000Z",
	//"edited": "2014-12-20T21:17:56.891000Z",
	//"url": "https://swapi.co/api/people/1/"
 //   }
}

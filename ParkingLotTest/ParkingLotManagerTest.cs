using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotManagerTest
    {
        [Fact]
        public void Manager_Should_Add_ParkingBoy_Successfully()
        {
            //given
            var parkingLot = new ParkingLot.ParkingLot("parkingLot_1");
            var parkingBoy_1 = new ParkingBoy("parkingBoy_1", parkingLot);
            var manager = new ParkingLotServiceManager("manager_1", parkingLot, new List<ParkingBoy>(new ParkingBoy[] { parkingBoy_1 }));
            //when
            var parkingBoy_2 = new ParkingBoy("parkingBoy_2", parkingLot);
            manager.AddParkingBoy(parkingBoy_2);
            //then
            Assert.True(manager.ManageParkingBoy(parkingBoy_2));
        }

        [Fact]
        public void Manager_Should_Park_And_Fetch_Car_Correctly()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot.ParkingLot("parkingLot_1", 3);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);
            var manager = new ParkingLotServiceManager("manager_1", parkingLot, new List<ParkingBoy>(new[] { parkingBoy }));

            //when
            newCustomer.PassCarToParkingBoy(manager);

            //then
            Assert.True(parkingLot.ContainCar(car));
            var carReturned = newCustomer.FetchCarFromParkingBoy(manager, newCustomer.GetTicket(0));
            Assert.Equal(car, carReturned);
        }

        [Fact]
        public void Manger_Should_Appoint_ParkingBoy_To_Park_And_Fetch()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot.ParkingLot("parkingLot_1", 3);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);
            var manager = new ParkingLotServiceManager("manager_1", parkingLot, new List<ParkingBoy>(new[] { parkingBoy }));

            //when
            var parkingResult = manager.ParkCarByParkingBoy(car, parkingBoy, out var parkErrorMessage);
            Assert.Equal("parkingLot_1", parkingResult.ParkingLotId);
            Assert.Equal("car_1", parkingResult.CarId);

            var carResult = manager.FetchCarByParkingBoy(parkingResult, parkingBoy, out var fetchErrorMessage);
            Assert.Equal(car, carResult);
        }

        [Fact]
        public void Manager_Should_Add_Error_Message_Given_Wrong_Ticket()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot.ParkingLot("parkingLot_1", 3);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);
            var manager = new ParkingLotServiceManager("manager_1", parkingLot, new List<ParkingBoy>(new[] { parkingBoy }));

            //when
            manager.ParkCarByParkingBoy(car, parkingBoy, out _);
            var resultOfWrongTicket = manager.FetchCarByParkingBoy(
                new ParkingTicket("another_parkingBoy", "new_Car", "new_Customer", "another_ParkingLot"), parkingBoy,
                out var errorMessage);
            var expectedMessage = "Unrecognized parking ticket.";

            //then
            Assert.Equal(expectedMessage, errorMessage);
        }

        [Fact]
        public void Manager_Should_Add_Error_Message_Given_Parked_Ticket()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot.ParkingLot("parkingLot_1", 3);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);
            var manager = new ParkingLotServiceManager("manager_1", parkingLot, new List<ParkingBoy>(new[] { parkingBoy }));

            //when
            var parkedTicket = manager.ParkCarByParkingBoy(car, parkingBoy, out _);
            manager.FetchCarByParkingBoy(parkedTicket, parkingBoy, out _);
            manager.FetchCarByParkingBoy(parkedTicket, parkingBoy, out var errorMessage);
            var expectedMessage = "Unrecognized parking ticket.";

            //then
            Assert.Equal(expectedMessage, errorMessage);
        }

        [Fact]
        public void Manager_Should_Add_Error_Message_Given_No_Ticket()
        {
            //given
            var parkingLot = new ParkingLot.ParkingLot("parkingLot_1", 3);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);
            var manager = new ParkingLotServiceManager("manager_1", parkingLot, new List<ParkingBoy>(new[] { parkingBoy }));

            //when
            manager.FetchCarByParkingBoy(null, parkingBoy, out var errorMessage);
            var expectedMessage = "Please provide your parking ticket.";

            //then
            Assert.Equal(expectedMessage, errorMessage);
        }

        [Fact]
        public void Manager_Should_Add_Error_Message_Given_Outof_Capacity()
        {
            //given
            var parkingLot = new ParkingLot.ParkingLot("parkingLot_1", 2);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);
            var car_1 = new Car("car_1");
            var car_2 = new Car("car_2");
            var car_3 = new Car("car_3");
            var manager = new ParkingLotServiceManager("manager_1", parkingLot, new List<ParkingBoy>(new[] { parkingBoy }));

            //when
            manager.ParkCarByParkingBoy(car_1, parkingBoy, out _);
            manager.ParkCarByParkingBoy(car_2, parkingBoy, out _);
            manager.ParkCarByParkingBoy(car_3, parkingBoy, out var errorMessage);
            var expectedMessage = "Not enough position.";

            //then
            Assert.Equal(expectedMessage, errorMessage);
        }
    }
}

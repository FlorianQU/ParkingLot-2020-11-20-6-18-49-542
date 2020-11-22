using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ErrorMessageTest
    {
        [Fact]
        public void ParkingBoy_Should_Add_Error_Message_Given_Wrong_Ticket()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot.ParkingLot(3);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);

            //when
            newCustomer.PassCarToParkingBoy(parkingBoy);
            var resultOfWrongTicket = parkingBoy.FetchCar(new ParkingTicket("another_parkingBoy", "new_Car", "new_Customer"), out var errorMessage);
            var expectedMessage = "Unrecognized parking ticket.";

            //then
            Assert.Equal(expectedMessage, errorMessage);
        }

        [Fact]
        public void ParkingBoy_Should_Add_Error_Message_Given_Parked_Ticket()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot.ParkingLot(3);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);

            //when
            var parkedTicket = parkingBoy.ParkCar(car, out _);
            parkingBoy.FetchCar(parkedTicket, out _);
            parkingBoy.FetchCar(parkedTicket, out var errorMessage);
            var expectedMessage = "Unrecognized parking ticket.";

            //then
            Assert.Equal(expectedMessage, errorMessage);
        }

        [Fact]
        public void ParkingBoy_Should_Add_Error_Message_Given_No_Ticket()
        {
            //given
            var parkingLot = new ParkingLot.ParkingLot(3);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);

            //when
            parkingBoy.FetchCar(null, out var errorMessage);
            var expectedMessage = "Please provide your parking ticket.";

            //then
            Assert.Equal(expectedMessage, errorMessage);
        }

        [Fact]
        public void ParkingBoy_Should_Add_Error_Message_Given_Outof_Capacity()
        {
            //given
            var parkingLot = new ParkingLot.ParkingLot(2);
            var parkingBoy = new ParkingBoy("parkingBoy_1", parkingLot);
            var car_1 = new Car("car_1");
            var car_2 = new Car("car_2");
            var car_3 = new Car("car_3");

            //when
            parkingBoy.ParkCar(car_1, out _);
            parkingBoy.ParkCar(car_2, out _);
            parkingBoy.ParkCar(car_3, out var errorMessage);
            var expectedMessage = "Not enough position.";

            //then
            Assert.Equal(expectedMessage, errorMessage);
        }
    }
}

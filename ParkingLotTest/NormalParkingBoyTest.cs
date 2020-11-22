using System.Collections.Generic;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class NormalParkingBoyTest
    {
        [Fact]
        public void Normal_ParkingBoy_Should_Park_And_Fetch_Car_Correctly()
        {
            //given
            var car_1 = new Car("car_1");
            var newCustomer_1 = new Customer("customer_1", car_1);
            var car_2 = new Car("car_2");
            var newCustomer_2 = new Customer("customer_2", car_2);
            var car_3 = new Car("car_3");
            var newCustomer_3 = new Customer("customer_1", car_3);
            var parkingLot_1 = new ParkingLot("parkingLot_1", 2);
            var parkingLot_2 = new ParkingLot("parkingLot_2", 3);
            var parkingBoy = new NormalParkingBoy("parkingBoy_1", new List<ParkingLot>(new[] { parkingLot_1, parkingLot_2 }));

            //when
            newCustomer_1.PassCarToParkingBoy(parkingBoy);
            newCustomer_2.PassCarToParkingBoy(parkingBoy);
            newCustomer_3.PassCarToParkingBoy(parkingBoy);

            //then
            Assert.True(parkingLot_1.ContainCar(car_1));
            Assert.True(parkingLot_1.ContainCar(car_2));
            Assert.True(parkingLot_2.ContainCar(car_3));
            var carReturned_1 = newCustomer_1.FetchCarFromParkingBoy(parkingBoy, newCustomer_1.GetTicket(0));
            var carReturned_2 = newCustomer_2.FetchCarFromParkingBoy(parkingBoy, newCustomer_2.GetTicket(0));
            var carReturned_3 = newCustomer_3.FetchCarFromParkingBoy(parkingBoy, newCustomer_3.GetTicket(0));
            Assert.Equal(car_1, carReturned_1);
            Assert.Equal(car_2, carReturned_2);
            Assert.Equal(car_3, carReturned_3);
        }

        [Fact]
        public void Normal_ParkingBoy_Should_Park_And_Fetch_Car_Correctly_Given_Multiple()
        {
            //given
            var car_1 = new Car("car_1");
            var newCustomer_1 = new Customer("customer_1", car_1);
            var car_2 = new Car("car_2");
            var newCustomer_2 = new Customer("customer_2", car_2);
            var parkingLot = new ParkingLot("parkingLot_1", 3);
            var parkingBoy = new NormalParkingBoy("parkingBoy_1", parkingLot);

            //when
            newCustomer_1.PassCarToParkingBoy(parkingBoy);
            newCustomer_2.PassCarToParkingBoy(parkingBoy);

            //then
            Assert.True(parkingLot.ContainCar(car_1));
            Assert.True(parkingLot.ContainCar(car_2));
            var carReturned_1 = newCustomer_1.FetchCarFromParkingBoy(parkingBoy, newCustomer_1.GetTicket(0));
            var carReturned_2 = newCustomer_2.FetchCarFromParkingBoy(parkingBoy, newCustomer_2.GetTicket(0));
            Assert.Equal(car_1, carReturned_1);
            Assert.Equal(car_2, carReturned_2);
        }

        [Fact]
        public void Normal_ParkingBoy_Should_Return_Null_Given_No_Ticket_Or_Wrong_Ticket()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot("parkingLot_1", 3);
            var parkingBoy = new NormalParkingBoy("parkingBoy_1", parkingLot);

            //when
            newCustomer.PassCarToParkingBoy(parkingBoy);
            var resultOfNoTicket = parkingBoy.FetchCar(null, out _);
            var resultOfWrongTicket = parkingBoy.FetchCar(new ParkingTicket("another_parkingBoy", "new_Car", "new_Customer", "another_ParkingLot"), out _);

            //then
            Assert.Null(resultOfNoTicket);
            Assert.Null(resultOfWrongTicket);
        }

        [Fact]
        public void Normal_ParkingBoy_Should_Fetch_Null_Given_Used_Ticket()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot("parkingLot_1", 3);
            var parkingBoy = new NormalParkingBoy("parkingBoy_1", parkingLot);

            //when
            newCustomer.PassCarToParkingBoy(parkingBoy);
            newCustomer.FetchCarFromParkingBoy(parkingBoy, newCustomer.GetTicket(0));
            var secondFetchResult = newCustomer.FetchCarFromParkingBoy(parkingBoy, newCustomer.GetTicket(0));
            //then
            Assert.Null(secondFetchResult);
        }

        [Fact]
        public void Normal_ParkingBoy_Should_Return_NullTicket_When_Over_Capacity()
        {
            //given
            var car_1 = new Car("car_1");
            var newCustomer_1 = new Customer("customer_1", car_1);
            var car_2 = new Car("car_2");
            var newCustomer_2 = new Customer("customer_2", car_2);
            var parkingLot = new ParkingLot("parkingLot_1", 1);
            var parkingBoy = new NormalParkingBoy("parkingBoy_1", parkingLot);

            //when
            newCustomer_1.PassCarToParkingBoy(parkingBoy);
            newCustomer_2.PassCarToParkingBoy(parkingBoy);

            //then
            Assert.Null(newCustomer_2.GetTicket(0));
        }

        [Fact]
        public void Normal_ParkingBoy_Should_Return_Null_Given_Parked_Car()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot("parkingLot_1", 3);
            var parkingBoy = new NormalParkingBoy("parkingBoy_1", parkingLot);

            //when
            newCustomer.PassCarToParkingBoy(parkingBoy);
            var resultGivenParkedCar = parkingBoy.ParkCar(car, out _);

            //then
            Assert.Null(resultGivenParkedCar);
        }

        [Fact]
        public void Normal_ParkingBoy_Should_Return_Null_Given_Null_Car()
        {
            //given
            var parkingLot = new ParkingLot("parkingLot_1", 3);
            var parkingBoy = new NormalParkingBoy("parkingBoy_1", parkingLot);

            //when
            var resultGivenParkedCar = parkingBoy.ParkCar(null, out _);

            //then
            Assert.Null(resultGivenParkedCar);
        }

        [Fact]
        public void Normal_ParkingBoy_Should_Choose_ParkingLot_In_Order()
        {
            //given
            var parkingLot_1 = new ParkingLot("parkingLot_1", 2);
            var parkingLot_2 = new ParkingLot("parkingLot_2", 3);
            var parkingBoy =
                new NormalParkingBoy("parkingBoy_1", new List<ParkingLot>(new[] { parkingLot_1, parkingLot_2 }));
            var car_1 = new Car("car_1");
            var car_2 = new Car("car_2");
            var car_3 = new Car("car_3");
            //when
            var parkingResult_1 = parkingBoy.ParkCar(car_1, out _);
            var parkingResult_2 = parkingBoy.ParkCar(car_2, out _);
            var parkingResult_3 = parkingBoy.ParkCar(car_3, out _);

            //then
            Assert.Equal("parkingLot_1", parkingResult_1.ParkingLotId);
            Assert.Equal("parkingLot_1", parkingResult_2.ParkingLotId);
            Assert.Equal("parkingLot_2", parkingResult_3.ParkingLotId);

            Assert.Equal("car_1", parkingResult_1.CarId);
            Assert.Equal("car_2", parkingResult_2.CarId);
            Assert.Equal("car_3", parkingResult_3.CarId);
        }
    }
}

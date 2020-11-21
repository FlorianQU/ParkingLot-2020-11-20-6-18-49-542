namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void ParkingBoy_Should_Park_And_Fetch_Car_Correctly()
        {
            //given
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);

            //when
            newCustomer.PassCarToParkingBoy(parkingBoy);

            //then
            Assert.True(parkingLot.ContainCar(car));
            var carReturned = newCustomer.FetchCarFromParkingBoy(parkingBoy, newCustomer.GetTicket(0));
            Assert.Equal(car, carReturned);
        }

        [Fact]
        public void ParkingBoy_Should_Park_And_Fetch_Car_Correctly_Given_Multiple()
        {
            //given
            var car_1 = new Car("car_1");
            var newCustomer_1 = new Customer("customer_1", car_1);
            var car_2 = new Car("car_2");
            var newCustomer_2 = new Customer("customer_2", car_2);
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);

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
    }
}

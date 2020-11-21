namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void ParkingBoy_Should_Park_And_Fetch_Car_Correctly()
        {
            var car = new Car("car_1");
            var newCustomer = new Customer("customer_1", car);
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            newCustomer.PassCarToParkingBoy(parkingBoy);
            Assert.True(parkingLot.ContainCar(car));
            var carReturned = newCustomer.FetchCarFromParkingBoy(parkingBoy, newCustomer.GetTicket(0));
            Assert.Equal(car, carReturned);
        }
    }
}

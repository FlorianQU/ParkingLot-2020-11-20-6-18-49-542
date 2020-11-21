namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        private ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string Id { get; }

        public ParkingTicket ParkCar(Car car)
        {
            this.parkingLot.AddCar(car);
            return new ParkingTicket(this.Id, car.Id, car.OwnerId);
        }

        public Car FetchCar(ParkingTicket parkingTicket)
        {
            return this.parkingLot.FindCar(parkingTicket.CarId);
        }
    }
}

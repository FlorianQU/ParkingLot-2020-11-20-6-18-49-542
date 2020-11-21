namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        private ParkingLot parkingLot;

        public ParkingBoy(string id, ParkingLot parkingLot)
        {
            Id = id;
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
            if (parkingTicket == null || parkingTicket.ParkingBoyId != this.Id)
            {
                return null;
            }

            return this.parkingLot.FindCar(parkingTicket.CarId);
        }
    }
}

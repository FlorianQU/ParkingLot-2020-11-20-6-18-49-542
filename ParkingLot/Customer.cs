using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Customer
    {
        private List<ParkingTicket> myTickets = new List<ParkingTicket>();
        private Car myCar;

        public Customer(string id, Car car)
        {
            this.Id = id;
            this.myCar = car;
            myCar.SetOwner(Id);
        }

        public string Id { get; }
        public void PassCarToParkingBoy(ParkingBoy parkingBoy)
        {
            this.myTickets.Add(parkingBoy.ParkCar(this.myCar));
        }

        public Car FetchCarFromParkingBoy(ParkingBoy parkingBoy, ParkingTicket parkingTicket)
        {
            return parkingBoy.FetchCar(parkingTicket);
        }

        public ParkingTicket GetTicket(int index)
        {
            return this.myTickets[index];
        }
    }
}

using System.Collections.Generic;

namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        private ParkingLot parkingLot;
        private List<ParkingTicket> ticketHistoryList = new List<ParkingTicket>();

        public ParkingBoy(string id, ParkingLot parkingLot)
        {
            Id = id;
            this.parkingLot = parkingLot;
        }

        public string Id { get; }

        public ParkingTicket ParkCar(Car car)
        {
            if (this.parkingLot.AddCar(car))
            {
                var parkingTicketGenerated = new ParkingTicket(this.Id, car.Id, car.OwnerId);
                ticketHistoryList.Add(parkingTicketGenerated);
                return parkingTicketGenerated;
            }

            return null;
        }

        public Car FetchCar(ParkingTicket parkingTicket)
        {
            if (parkingTicket == null || !ticketHistoryList.Contains(parkingTicket) || parkingTicket.IsUsed)
            {
                return null;
            }

            return this.parkingLot.FindCar(parkingTicket.CarId);
        }
    }
}

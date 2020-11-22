using System.Collections.Generic;
using static System.String;

namespace ParkingLot
{
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

        public ParkingTicket ParkCar(Car car, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (car != null && this.parkingLot.AddCar(car))
            {
                var parkingTicketGenerated = new ParkingTicket(this.Id, car.Id, car.OwnerId);
                ticketHistoryList.Add(parkingTicketGenerated);
                return parkingTicketGenerated;
            }

            errorMessage += "Not enough position.";
            return null;
        }

        public Car FetchCar(ParkingTicket parkingTicket, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (parkingTicket == null)
            {
                errorMessage += "Please provide your parking ticket.";
                return null;
            }

            if (!ticketHistoryList.Contains(parkingTicket) || parkingTicket.IsUsed)
            {
                errorMessage += "Unrecognized parking ticket.";
                return null;
            }

            parkingTicket.UseTicket();
            return this.parkingLot.FindCar(parkingTicket.CarId);
        }
    }
}

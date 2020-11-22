using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLotList = new List<ParkingLot>();
        private ParkingLot parkingLotForParking;
        private List<ParkingTicket> ticketHistoryList = new List<ParkingTicket>();
        private ParkingLot parkingLotForFetching;

        public ParkingBoy(string id, ParkingLot parkingLot)
        {
            Id = id;
            this.ParkingLotForParking = parkingLot;
            this.parkingLotForFetching = parkingLot;
            this.ParkingLotList.Add(parkingLot);
        }

        public ParkingBoy(string id, List<ParkingLot> parkingLotList)
        {
            Id = id;
            this.ParkingLotList = parkingLotList;
            this.ParkingLotForParking = parkingLotList[0];
            this.parkingLotForFetching = parkingLotList[0];
        }

        public string Id { get; }

        protected List<ParkingLot> ParkingLotList
        {
            get => parkingLotList;
            set => parkingLotList = value;
        }

        protected ParkingLot ParkingLotForParking
        {
            get => parkingLotForParking;
            set => parkingLotForParking = value;
        }

        public virtual ParkingTicket ParkCar(Car car, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (car != null && this.ParkingLotForParking.AddCar(car))
            {
                var parkingTicketGenerated = new ParkingTicket(this.Id, car.Id, car.OwnerId, ParkingLotForParking.Id);
                ticketHistoryList.Add(parkingTicketGenerated);
                return parkingTicketGenerated;
            }

            errorMessage = "Not enough position.";
            return null;
        }

        public Car FetchCar(ParkingTicket parkingTicket, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (parkingTicket == null)
            {
                errorMessage = "Please provide your parking ticket.";
                return null;
            }

            if (!ticketHistoryList.Contains(parkingTicket) || parkingTicket.IsUsed)
            {
                errorMessage = "Unrecognized parking ticket.";
                return null;
            }

            this.parkingLotForFetching = GetParkingLotFromTicket(parkingTicket);
            if (parkingLotForFetching == null)
            {
                errorMessage = "Cannot find the corresponding parking lot.";
                return null;
            }

            parkingTicket.UseTicket();
            return this.parkingLotForFetching.FindCar(parkingTicket.CarId);
        }

        public ParkingLot GetParkingLotFromTicket(ParkingTicket parkingTicket)
        {
            if (ParkingLotList.Any(lot => lot.Id == parkingTicket.ParkingLotId))
            {
                return ParkingLotList.Find(lot => lot.Id == parkingTicket.ParkingLotId);
            }

            return null;
        }
    }
}

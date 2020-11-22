using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLotServiceManager : ParkingBoy
    {
        private List<ParkingBoy> parkingBoys = new List<ParkingBoy>();
        public ParkingLotServiceManager(string id, ParkingLot parkingLot, List<ParkingBoy> parkingBoys) : base(id, parkingLot)
        {
            this.parkingBoys = parkingBoys;
        }

        public ParkingLotServiceManager(string id, List<ParkingLot> parkingLotList, List<ParkingBoy> parkingBoys) : base(id, parkingLotList)
        {
            this.parkingBoys = parkingBoys;
        }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            if (!parkingBoys.Contains(parkingBoy))
            {
                parkingBoys.Add(parkingBoy);
            }
        }

        public ParkingTicket ParkCarByParkingBoy(Car car, ParkingBoy parkingBoy, out string errorMessage)
        {
            return parkingBoy.ParkCar(car, out errorMessage);
        }

        public Car FetchCarByParkingBoy(ParkingTicket parkingTicket, ParkingBoy parkingBoy, out string errorMessage)
        {
            return parkingBoy.FetchCar(parkingTicket, out errorMessage);
        }

        public bool ManageParkingBoy(ParkingBoy parkingBoy)
        {
            return this.parkingBoys.Contains(parkingBoy);
        }
    }
}

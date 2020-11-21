using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingTicket
    {
        public ParkingTicket(string parkingBoyId, string carId, string carOwnerId)
        {
            ParkingBoyId = parkingBoyId;
            CarId = carId;
            CarOwnerId = carOwnerId;
        }

        public string ParkingBoyId { get; }
        public string CarId { get; }
        public string CarOwnerId { get; }
    }
}

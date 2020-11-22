using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingTicket
    {
        public ParkingTicket(string parkingBoyId, string carId, string carOwnerId, string parkingLotId)
        {
            ParkingBoyId = parkingBoyId;
            CarId = carId;
            CarOwnerId = carOwnerId;
            ParkingLotId = parkingLotId;
        }

        public string ParkingBoyId { get; }
        public string CarId { get; }
        public string CarOwnerId { get; }
        public string ParkingLotId { get; }

        public bool IsUsed { get; private set; }

        public void UseTicket()
        {
            this.IsUsed = true;
        }
    }
}

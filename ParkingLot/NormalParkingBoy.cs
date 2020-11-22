using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class NormalParkingBoy : ParkingBoy, IChooseParkingLot
    {
        public NormalParkingBoy(string id, ParkingLot parkingLot) : base(id, parkingLot)
        {
        }

        public NormalParkingBoy(string id, List<ParkingLot> parkingLotList) : base(id, parkingLotList)
        {
        }

        public override ParkingTicket ParkCar(Car car, out string errorMessage)
        {
            this.ParkingLotForParking = ChooseParkingLot();
            return base.ParkCar(car, out errorMessage);
        }

        public ParkingLot ChooseParkingLot()
        {
            var parkingLotChosen = ParkingLotList.Find(lot => !lot.IsFull);
            return parkingLotChosen ?? ParkingLotList[^1];
        }
    }
}

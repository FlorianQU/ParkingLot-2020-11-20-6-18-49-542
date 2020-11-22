using System;
using System.Collections.Generic;
using System.Linq;
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
            var parkingLotsChosen = ParkingLotList.Where(lot => !lot.IsFull).ToList();
            return parkingLotsChosen.Any() ? parkingLotsChosen.First() : ParkingLotList[^1];
        }
    }
}

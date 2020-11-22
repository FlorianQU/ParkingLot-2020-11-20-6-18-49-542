using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class CleverParkingBoy : ParkingBoy, IChooseParkingLot
    {
        public CleverParkingBoy(string id, ParkingLot parkingLot) : base(id, parkingLot)
        {
        }

        public CleverParkingBoy(string id, List<ParkingLot> parkingLotList) : base(id, parkingLotList)
        {
        }

        public override ParkingTicket ParkCar(Car car, out string errorMessage)
        {
            this.ParkingLotForParking = ChooseParkingLot();
            return base.ParkCar(car, out errorMessage);
        }

        public ParkingLot ChooseParkingLot()
        {
            var parkingLotChosen = ParkingLotList.Where(lot => !lot.IsFull).ToList();
            return parkingLotChosen.Any()
                ? parkingLotChosen.OrderBy(lot => lot.LotAvailable).First()
                : ParkingLotList[^1];
        }
    }
}

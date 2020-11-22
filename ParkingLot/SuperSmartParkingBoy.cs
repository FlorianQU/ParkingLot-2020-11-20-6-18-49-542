using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class SuperCleverParkingBoy : ParkingBoy, IChooseParkingLot
    {
        public SuperCleverParkingBoy(string id, ParkingLot parkingLot) : base(id, parkingLot)
        {
        }

        public SuperCleverParkingBoy(string id, List<ParkingLot> parkingLotList) : base(id, parkingLotList)
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
                ? parkingLotChosen.OrderByDescending(lot => lot.AvailablePositionRate).First()
                : ParkingLotList[^1];
        }
    }
}
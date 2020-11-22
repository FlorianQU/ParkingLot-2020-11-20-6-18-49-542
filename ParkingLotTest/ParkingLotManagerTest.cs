using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotManagerTest
    {
        [Fact]
        public void Manager_Should_Add_ParkingBoy_Successfully()
        {
            //given
            var parkingLot = new ParkingLot.ParkingLot("parkingLot_1");
            var parkingBoy_1 = new ParkingBoy("parkingBoy_1", parkingLot);
            var manager = new ParkingLotServiceManager("manager_1", parkingLot, new List<ParkingBoy>(new ParkingBoy[] { parkingBoy_1 }));
            //when
            var parkingBoy_2 = new ParkingBoy("parkingBoy_2", parkingLot);
            manager.AddParkingBoy(parkingBoy_2);
            //then
            Assert.True(manager.ManageParkingBoy(parkingBoy_2));
        }
    }
}

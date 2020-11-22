using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Customer
    {
        private List<ParkingTicket> myTickets = new List<ParkingTicket>();
        private Car myCar;
        private List<string> errorMessageBox = new List<string>();

        public Customer(string id, Car car)
        {
            this.Id = id;
            this.myCar = car;
            myCar.SetOwner(Id);
        }

        public string Id { get; }
        public void PassCarToParkingBoy(ParkingBoy parkingBoy)
        {
            this.myTickets.Add(parkingBoy.ParkCar(this.myCar, out var errorMessage));
            AddMessage(errorMessage);
        }

        public Car FetchCarFromParkingBoy(ParkingBoy parkingBoy, ParkingTicket parkingTicket)
        {
            var resultCar = parkingBoy.FetchCar(parkingTicket, out var errorMessage);
            AddMessage(errorMessage);
            return resultCar;
        }

        public ParkingTicket GetTicket(int index)
        {
            return this.myTickets[index];
        }

        public string GetLatestMessage()
        {
            return errorMessageBox[-1];
        }

        private void AddMessage(string errorMessage)
        {
            if (errorMessage != null)
            {
                this.errorMessageBox.Add(errorMessage);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLot
    {
        private List<Car> parkedCars = new List<Car>();

        public ParkingLot(long capacity)
        {
            this.Capacity = capacity;
        }

        public long Capacity { get; } = 10;

        public bool AddCar(Car car)
        {
            if (parkedCars.Count < Capacity)
            {
                this.parkedCars.Add(car);
                return true;
            }

            return false;
        }

        public Car FindCar(string carId)
        {
            var foundResult = parkedCars.Find(car => car.Id == carId);
            if (foundResult != null)
            {
                parkedCars.Remove(foundResult);
            }

            return foundResult;
        }

        public bool ContainCar(Car car)
        {
            return parkedCars.Contains(car);
        }
    }
}

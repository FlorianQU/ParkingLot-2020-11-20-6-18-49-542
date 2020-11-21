using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingLot
    {
        private List<Car> parkedCars = new List<Car>();

        public void AddCar(Car car)
        {
            this.parkedCars.Add(car);
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

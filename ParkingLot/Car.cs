using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Car
    {
        public Car(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public string OwnerId { get; private set; }

        public void SetOwner(string ownerId)
        {
            this.OwnerId = ownerId;
        }
    }
}

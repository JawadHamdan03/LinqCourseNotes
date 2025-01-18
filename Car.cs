using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectC_
{
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public int manufYear { get; set; }
        public string  VIN { get; set; }
        public string color { get; set; }
        public int MaxSpeed { get; set; }



        public Car(int id , string name , string model , int manufYear, string VIN, string color,int MaxSpeed)
        {
            this.id = id;
            this.name = name;
            this.model = model;
            this.manufYear = manufYear;
            this.VIN = VIN;
            this.color = color;
            this.MaxSpeed = MaxSpeed;
        }

        public override string ToString()
        {
            return $"ID:{id}, name:{name}, model:{model}, manufYear:{manufYear}, VIN:{VIN}, Color:{color}, maxspeed:{MaxSpeed}";
        }
    }
}



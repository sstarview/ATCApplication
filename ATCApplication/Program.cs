using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      //object initializer 
      Plane someBoeing777 = new Plane
      {
        Identifier = "BA0049",
        Direction = DirectionOfApproach.Approaching,
        SpeedInMilesPerHour=150.0,
      };
      //someBoeing777.Identifier = "BA0049";
      //someBoeing777.SpeedInMilesPerHour = 150.0;
      //someBoeing777.Direction = DirectionOfApproach.Approaching;

      Console.WriteLine("Your plane has identifier {0}, " + "and is travelling at {1:0.00}mph [{2:0.00}kph] and direction is {3}",
        someBoeing777.Identifier, someBoeing777.SpeedInMilesPerHour, someBoeing777.SpeedInKilometersPerHour, someBoeing777.Direction);

      someBoeing777.SpeedInKilometersPerHour = 140.0;
      Console.WriteLine("Your plane has identifier {0}, " + "and is traveling at {1:0.00}mph [{2:0.00}kph]",
        someBoeing777.Identifier,
        someBoeing777.SpeedInMilesPerHour,
        someBoeing777.SpeedInKilometersPerHour);

      //Plane plane = new Plane("Ramesh");
      //plane.Position = new PolarPoint3D(124.2, 125.6, 87.369);

      Plane plane = new Plane();
      plane.Direction = DirectionOfApproach.Approaching;
      plane.Identifier = "MYPLANE";
      plane.SpeedInKilometersPerHour = 120;
      plane.Position = new PolarPoint3D(65, 20, 745);
      Console.WriteLine(plane.Position.Distance);



      Console.ReadKey();
    }
  }
}

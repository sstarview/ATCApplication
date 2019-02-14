using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCApplication
{
  class Plane
  {
    //modifying the code for object initializer 
    //no need of constructor

    //public Plane(string newIdentifier)
    //{
    //  _identifier = newIdentifier;
    //}

    //public string Identifier
    //{
    //  get { return _identifier; }
    //}

    //private readonly string _identifier; //{ get; private set; }

    public string Identifier { get; set; }

    //fields are private by default.
    //its a good practice to write all the access modifier
    private const double kilometersPerMile = 1.609344;

    public double SpeedInMilesPerHour { get; set; }
    public double SpeedInKilometersPerHour
    {
      get
      {
        return SpeedInMilesPerHour * kilometersPerMile;
      }
      set
      {
        SpeedInMilesPerHour = value / kilometersPerMile;
      }
    }

    public DirectionOfApproach Direction { get; set; }
    public PolarPoint3D Position { get; set; }

    public void UpdatePosition(double minutesToAdvance)
    {
      double hour = minutesToAdvance / 60;
      double milesMoved = SpeedInMilesPerHour * 60;
      double milesToTower = Position.Distance;
      if (Direction == DirectionOfApproach.Approaching)
      {
        milesToTower -= milesMoved;
        if (milesToTower < 0)
        {
          milesToTower = 0;
        }
      }
      else
      {
        milesToTower += milesMoved;
      }

      PolarPoint3D newPosition = new PolarPoint3D(milesToTower, Position.Angle, Position.Altitude);
    }

    private const double feetPerMile = 5280;

    public static bool TooClose(Plane first, Plane second, double minimumMiles)
    {
      double x1 = first.Position.Distance * Math.Cos(first.Position.Angle);
      double x2 = second.Position.Distance * Math.Cos(second.Position.Angle);
      double y1 = first.Position.Distance * Math.Sin(first.Position.Angle);
      double y2 = second.Position.Distance * Math.Sin(second.Position.Angle);
      double z1 = first.Position.Altitude / feetPerMile;
      double z2 = second.Position.Altitude / feetPerMile;
      double dx = x1 - x2;
      double dy = y1 - y2;
      double dz = z1 - z2;
      double distanceSquared = dx * dx + dy * dy + dz * dz;
      double minimumSquared = minimumMiles * minimumMiles;
      return distanceSquared < minimumSquared;
    }
  }
}

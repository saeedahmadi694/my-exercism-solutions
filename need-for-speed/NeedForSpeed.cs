using System;

class RemoteControlCar
{
    private int Speed;
    private int BatteryDrain;
    private int Distance;
    private int BatteryPercentage;

    public RemoteControlCar()
    {
        Distance = 0;
        BatteryPercentage = 100;
    }
    public RemoteControlCar(int speed, int batteryDrain) : this()
    {

        Speed = speed;
        BatteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return BatteryPercentage < BatteryDrain;
    }

    public int DistanceDriven()
    {
        return Distance;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            Distance += Speed;
            BatteryPercentage -= BatteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    public int Distance { get; private set; }

    public RaceTrack(int distance)
    {
        Distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() < Distance)
        {
            car.Drive();
        }

        return car.DistanceDriven() >= Distance;
    }
}

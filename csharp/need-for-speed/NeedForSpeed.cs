public class RemoteControlCar {
    private int battery;
    private int driven;

    private readonly int speed;
    private readonly int batteryDrain;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;

        driven = 0;
        battery = 100;
    }

    public bool BatteryDrained() => battery - batteryDrain < 0;

    public int DistanceDriven() => driven;

    public void Drive()
    {
        if (BatteryDrained())
            return;

        driven += speed;
        battery -= batteryDrain;
    }

    public static RemoteControlCar Nitro() =>
        new(speed: 50, batteryDrain: 4);
}

public class RaceTrack {
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        do car.Drive();
        while (!car.BatteryDrained());

        return car.DistanceDriven() >= distance;
    }
}
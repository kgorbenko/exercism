public class RemoteControlCar {
    private int distanceDriven;
    private int batteryLeft;

    public RemoteControlCar() {
        distanceDriven = 0;
        batteryLeft = 100;
    }

    public static RemoteControlCar Buy()
        => new();

    public string DistanceDisplay() =>
        $"Driven {distanceDriven} meters";

    public string BatteryDisplay()
        => batteryLeft > 0
            ? $"Battery at {batteryLeft}%"
            : "Battery empty";

    public void Drive()
    {
        if (batteryLeft <= 0)
            return;

        batteryLeft -= 1;
        distanceDriven += 20;
    }
}

using System;

static class Appointment {
    public static DateTime Schedule(string appointmentDateDescription) =>
        DateTime.Parse(appointmentDateDescription);

    public static bool HasPassed(DateTime appointmentDate) =>
        appointmentDate < DateTime.Now;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) =>
        appointmentDate.Hour is >= 12 and < 18;

    public static string Description(DateTime appointmentDate) =>
        $"You have an appointment on {appointmentDate}.";

    public static DateTime AnniversaryDate() =>
        new(year: DateTime.Now.Year, month: 9, day: 15);
}
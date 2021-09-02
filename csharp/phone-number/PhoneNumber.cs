using System;
using System.Linq;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        phoneNumber = string.Join("", phoneNumber.Where(c => char.IsNumber(c)).Select(c => c.ToString()));

        if (phoneNumber.StartsWith('1')) phoneNumber = phoneNumber.Remove(0, 1);
        if (phoneNumber.Length > 10 || phoneNumber.Length < 10) throw new ArgumentException();

        if (phoneNumber[0] == '0' ||
            phoneNumber[0] == '1' ||
            phoneNumber[3] == '0' ||
            phoneNumber[3] == '1')
            throw new ArgumentException();

        return phoneNumber;
    }
}
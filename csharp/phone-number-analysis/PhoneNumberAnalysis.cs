public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var (dialingCode, prefixCode, localCode) = (phoneNumber[..3], phoneNumber[4..7], phoneNumber[8..]);

        return (dialingCode == "212", prefixCode == "555", localCode);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
        => phoneNumberInfo.IsFake;
}

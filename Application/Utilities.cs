using System.Globalization;

namespace ConsoleCustom;

public static class Utilities
{
    // public static DateTime ParseOfxDateTime(double dateTime) =>
    //     DateTime.ParseExact(dateTime.ToString(CultureInfo.InvariantCulture), dateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
    //
    //2024  10  27  T   22  59  59
    //2024  10  27  T   22  59  59

    public static DateTime ParseOfxDateTime(UInt64 dateTime) =>
        ParseCustom(dateTime.ToString());
    
    public static DateTime ParseOfxDateTime(double dateTime) =>
        ParseCustom(dateTime.ToString(CultureInfo.InvariantCulture));
    
    
    public static DateTime ParseOfxDateTime(string dateTime) =>
        ParseCustom(dateTime);

    public static DateTime ParseOfxDateTime(UInt16 dateTime) =>
        ParseCustom(dateTime.ToString());
    
    public static DateTime ParseOfxDateTime(UInt32 dateTime) =>
        ParseCustom(dateTime.ToString());

    public static DateTime ParseOfxDateTime(int dateTime) =>
        ParseCustom(dateTime.ToString());

    private static DateTime ParseCustom(string raw)
    {
        DateTime result = DateTime.ParseExact(raw, dateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);

        DateTimeKind kind = result.Kind;

        if (result.Kind == DateTimeKind.Unspecified)
        {
            return DateTime.SpecifyKind(result, DateTimeKind.Utc);
        }
        return result;

    }
    
    
    private static readonly string[] dateTimeFormats = 
    [
        "yyyyMMddHHmmss",
        "yyyyMMddHHmm",
        "yyyyMMdd",
        "O",
        "yyyyMMddHHmmssK",
        "yyyyMMddHHmmK"
    ];

}
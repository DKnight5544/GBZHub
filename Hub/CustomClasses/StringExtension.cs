
/// <summary>
/// This class contain extension functions for string objects
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Returns characters from right of specified length
    /// </summary>
    /// <param name="value">String value</param>
    /// <param name="length">Max number of charaters to return</param>
    /// <returns>Returns string from right</returns>
    public static string Right(this string value, int length)
    {
        return value != null && value.Length > length ? value.Substring(value.Length - length) : value;
    }

    /// <summary>
    /// Returns characters from left of specified length
    /// </summary>
    /// <param name="value">String value</param>
    /// <param name="length">Max number of charaters to return</param>
    /// <returns>Returns string from left</returns>
    public static string Left(this string value, int length)
    {
        return value != null && value.Length > length ? value.Substring(0, length) : value;
    }

}
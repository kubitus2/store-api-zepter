namespace ZepterApi.Utilities;

public static class Helpers
{
    private static Random _random = new Random();

    public static T GetRandomEnumValue<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(_random.Next(values.Length));
    }

    public static T GetRandomElement<T>(T[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array cannot be null or empty.", nameof(array));

        return array[_random.Next(array.Length)];
    }
}

using Godot;
/// <summary>
/// Extensions for arrays
/// </summary>
public static class ArrayExtensions
{
    private static readonly RandomNumberGenerator _rand = new RandomNumberGenerator();

    #region GetRandom
    /// <summary>
    /// Gets a random entry from the entire array
    /// </summary>
    /// <typeparam name="T">The type (deduced from the array parameter)</typeparam>
    /// <param name="array">The array</param>
    /// <param name="rand"></param>
    /// <returns>A random object. If the array is null or empty, returns default(T)</returns>
    public static T GetRandom<T>(this T[] array, RandomNumberGenerator rand = null)
    {
        // Empty array, return default value
        if (array == null || array.Length == 0)
            return default;

        // Only one object, return it
        if (array.Length == 1)
            return array[0];

        // Return a random entry from the entire array
        return array[(rand ?? _rand).RandiRange(0, array.Length - 1)];
    }
    #endregion
}

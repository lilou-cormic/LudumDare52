using Godot;
/// <summary>
/// FROM UNITY
/// </summary>
public static class ColorEx
{
    /// <summary>
    /// Linearly interpolates between colors a and b by t. (clamps t between 0 and 1)
    /// </summary>
    /// <param name="a">Start value, returned when t = 0.</param>
    /// <param name="b">End value, returned when t = 1.</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value, equals to a + (b - a) * t.</returns>
    public static Color Lerp(Color a, Color b, float t)
    {
        t = Mathf.Clamp(t, 0f, 1f);
        return new Color(a.r + (b.r - a.r) * t, a.g + (b.g - a.g) * t, a.b + (b.b - a.b) * t, a.a + (b.a - a.a) * t);
    }

    /// <summary>
    /// Linearly interpolates between colors a and b by t. (t is not clamped)
    /// </summary>
    /// <param name="a">Start value, returned when t = 0.</param>
    /// <param name="b">End value, returned when t = 1.</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value, equals to a + (b - a) * t.</returns>
    public static Color LerpUnclamped(Color a, Color b, float t)
    {
        return new Color(a.r + (b.r - a.r) * t, a.g + (b.g - a.g) * t, a.b + (b.b - a.b) * t, a.a + (b.a - a.a) * t);
    }
}

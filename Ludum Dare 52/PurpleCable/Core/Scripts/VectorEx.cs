using Godot;
using System;

/// <summary>
/// FROM UNITY
/// </summary>
public static class VectorEx
{
    public static Vector3 ToVector3(this Vector2 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }

    public static Vector2 ToVector2(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }

    public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float deltaTime, float maxSpeed = float.PositiveInfinity)
    {
        Vector3 currentVelocity3 = currentVelocity.ToVector3();

        Vector3 outVector3 = SmoothDamp(current.ToVector3(), target.ToVector3(), ref currentVelocity3, smoothTime, deltaTime, maxSpeed);

        currentVelocity = currentVelocity3.ToVector2();

        return outVector3.ToVector2();
    }

    public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float deltaTime, float maxSpeed = float.PositiveInfinity)
    {
        float num = 0f;
        float num2 = 0f;
        float num3 = 0f;
        smoothTime = Mathf.Max(0.0001f, smoothTime);
        float num4 = 2f / smoothTime;
        float num5 = num4 * deltaTime;
        float num6 = 1f / (1f + num5 + 0.48f * num5 * num5 + 0.235f * num5 * num5 * num5);
        float num7 = current.x - target.x;
        float num8 = current.y - target.y;
        float num9 = current.z - target.z;
        Vector3 vector = target;
        float num10 = maxSpeed * smoothTime;
        float num11 = num10 * num10;
        float num12 = num7 * num7 + num8 * num8 + num9 * num9;
        if (num12 > num11)
        {
            float num13 = (float)Math.Sqrt(num12);
            num7 = num7 / num13 * num10;
            num8 = num8 / num13 * num10;
            num9 = num9 / num13 * num10;
        }

        target.x = current.x - num7;
        target.y = current.y - num8;
        target.z = current.z - num9;
        float num14 = (currentVelocity.x + num4 * num7) * deltaTime;
        float num15 = (currentVelocity.y + num4 * num8) * deltaTime;
        float num16 = (currentVelocity.z + num4 * num9) * deltaTime;
        currentVelocity.x = (currentVelocity.x - num4 * num14) * num6;
        currentVelocity.y = (currentVelocity.y - num4 * num15) * num6;
        currentVelocity.z = (currentVelocity.z - num4 * num16) * num6;
        num = target.x + (num7 + num14) * num6;
        num2 = target.y + (num8 + num15) * num6;
        num3 = target.z + (num9 + num16) * num6;
        float num17 = vector.x - current.x;
        float num18 = vector.y - current.y;
        float num19 = vector.z - current.z;
        float num20 = num - vector.x;
        float num21 = num2 - vector.y;
        float num22 = num3 - vector.z;
        if (num17 * num20 + num18 * num21 + num19 * num22 > 0f)
        {
            num = vector.x;
            num2 = vector.y;
            num3 = vector.z;
            currentVelocity.x = (num - vector.x) / deltaTime;
            currentVelocity.y = (num2 - vector.y) / deltaTime;
            currentVelocity.z = (num3 - vector.z) / deltaTime;
        }

        return new Vector3(num, num2, num3);
    }

    /// <summary>
    /// Linearly interpolates between two points. (clamps t between 0 and 1)
    /// </summary>
    /// <param name="a">Start value, returned when t = 0.</param>
    /// <param name="b">End value, returned when t = 1.</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value, equals to a + (b - a) * t.</returns>
    public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        => Lerp(a.ToVector3(), b.ToVector3(), t).ToVector2();

    /// <summary>
    /// Linearly interpolates between two vectors. (t is not clamped)
    /// </summary>
    /// <param name="a">Start value, returned when t = 0.</param>
    /// <param name="b">End value, returned when t = 1.</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value, equals to a + (b - a) * t.</returns>
    public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
        => LerpUnclamped(a.ToVector3(), b.ToVector3(), t).ToVector2();

    /// <summary>
    /// Linearly interpolates between two points. (clamps t between 0 and 1)
    /// </summary>
    /// <param name="a">Start value, returned when t = 0.</param>
    /// <param name="b">End value, returned when t = 1.</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value, equals to a + (b - a) * t.</returns>
    public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        t = Mathf.Clamp(t, 0f, 1f);
        return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
    }

    /// <summary>
    /// Linearly interpolates between two vectors. (t is not clamped)
    /// </summary>
    /// <param name="a">Start value, returned when t = 0.</param>
    /// <param name="b">End value, returned when t = 1.</param>
    /// <param name="t">Value used to interpolate between a and b.</param>
    /// <returns>Interpolated value, equals to a + (b - a) * t.</returns>
    public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t)
    {
        return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
    }
}

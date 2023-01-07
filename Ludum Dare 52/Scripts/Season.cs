using System;

[Flags]
public enum Season
{
    Spring = 1,
    Summer = 2,
    Fall = 4,
    SummerAndFall = Summer | Fall,
}

// From http://www.huwyss.com/level-it/localization-textmanager-for-unity3d

using System.Collections.Generic;

public class PlayerPrefs
{
    private static Dictionary<string, object> _prefs = new Dictionary<string, object>();

    private static T GetValue<T>(string prefName, T defaultValue)
    {
        //TODO Godot - Load

        if (_prefs.TryGetValue(prefName, out object value) && value is T typedValue)
            return typedValue;

        return defaultValue;
    }

    private static void SetValue(string prefName, object value)
    {
        _prefs[prefName] = value;

        //TODO Godot - Save
    }

    public static string GetString(string prefName, string defaultValue = null) => GetValue(prefName, defaultValue);

    public static void SetString(string prefName, string value) => SetValue(prefName, value);

    public static int GetInt(string prefName, int defaultValue = 0) => GetValue(prefName, defaultValue);

    public static void SetInt(string prefName, int value) => SetValue(prefName, value);

    public static float GetFloat(string prefName, float defaultValue = 0) => GetValue(prefName, defaultValue);

    public static void SetFloat(string prefName, float value) => SetValue(prefName, value);
}

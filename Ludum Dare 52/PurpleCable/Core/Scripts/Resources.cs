using Godot;
using System.Collections.Generic;

public static class Resources
{
    public static TResource Load<TResource>(string fileName)
        where TResource : Resource
    {
        return GD.Load<TResource>(@"res://Resources/" + fileName);
    }

    public static TResource Load<TResource>(string folder, string fileName)
        where TResource : Resource
    {
        return GD.Load<TResource>(@"res://Resources/" + folder + @"/" + fileName);
    }

    public static List<TResource> LoadAll<TResource>(string path)
        where TResource : Resource
    {
        List<TResource> resources = new List<TResource>();

        Directory dir = new Directory();
        Error error = dir.Open(@"res://Resources/" + path);

        if (error == Error.Ok)
        {
            dir.ListDirBegin();
            string fileName = dir.GetNext();
            while (!string.IsNullOrEmpty(fileName))
            {
                if (!dir.CurrentIsDir())
                    resources.Add(GD.Load(fileName).GetScript() as TResource);

                fileName = dir.GetNext();
            }
            dir.ListDirEnd();
        }
        else
        {
            GD.PushError($"Resources.LoadAll({path}) - {error}");
        }

        return resources;
    }
}

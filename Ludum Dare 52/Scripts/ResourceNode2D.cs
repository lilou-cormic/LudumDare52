using Godot;
using System.Collections.Generic;

public class ResourceNode2D : Node2D
{
    [Export] public Resource[] Resources;

    public List<TResource> LoadAll<TResource>()
       where TResource : Resource
    {
        List<TResource> resources = new List<TResource>();

        foreach (var item in Resources)
        {
            if (item is TResource resource)
            {
                resources.Add(resource);
            }
        }

        return resources;
    }
}

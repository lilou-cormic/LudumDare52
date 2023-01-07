using Godot;

public static class NodeExtensions
{
    public static TNode Instantiate<TNode>(this Node node, PackedScene model)
        where TNode : Node
    {
        TNode newNode = model.Instance<TNode>();
        node.AddChild(newNode);

        return newNode;
    }

    public static TNode2D Instantiate<TNode2D>(this Node node, PackedScene model, Vector2 globalPosition, float globalRotation)
        where TNode2D : Node2D
    {
        TNode2D newNode = model.Instance<TNode2D>();
        node.AddChild(newNode);
        newNode.GlobalPosition = globalPosition;
        newNode.GlobalRotation = globalRotation;

        return newNode;
    }

    public static TNode GetInParents<TNode>(this Node node, string name)
        where TNode : Node
    {
        return node.FindParent(name).GetParent().GetNode<TNode>(name);
    }

    public static void SetActive(this Node2D node2D, bool active)
    {
        node2D.Visible = active;
        node2D.SetProcess(active);
    }
}

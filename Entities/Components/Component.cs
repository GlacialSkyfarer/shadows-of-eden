using Godot;

[Icon("res://Icons/icn_Component.svg")]
public partial class Component : Node
{
    public IEntity GetEntity()
    {
        Node owner = GetParentOrNull<Node>().GetParentOrNull<Node>();

        if (!(owner is IEntity)) return null;
        return owner as IEntity;
    }
}

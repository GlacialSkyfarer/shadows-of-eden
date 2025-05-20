using Godot;

[GlobalClass]
public partial class CrosshairComponent : Component
{
    [Export] public NodePath CrosshairPath;
    [Export] public NodePath CastPath;
}

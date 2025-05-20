using Godot;

[GlobalClass]
public partial class GravityComponent : Component
{

    [Export] public float Multiplier = 1.0f;
    [Export] public Vector3 Direction = Vector3.Down;

}

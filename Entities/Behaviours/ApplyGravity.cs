using Godot;

[GlobalClass]
public partial class ApplyGravity : Behaviour
{

    private GravityComponent gravity;
    [Export] private NodePath characterBodyPath;
    private CharacterBody3D characterBody;

    public override void _EntityReady()
    {

        if (!GetComponentVariable<GravityComponent>(out gravity)) return;
        characterBody = GetNode<CharacterBody3D>(characterBodyPath);

        base._EntityReady();

    }

    protected override void _BehaviourPhysicsProcess(double delta)
    {

        Vector3 velocity = characterBody.Velocity;
        velocity += gravity.Direction
            * gravity.Multiplier
            * characterBody.GetGravity().Length()
            * (float)delta;

        characterBody.Velocity = velocity;

    }

}

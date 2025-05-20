using Godot;

[GlobalClass]
public partial class FollowDesiredDirection : Behaviour
{

    private DesiredDirection desiredDirection;

    [Export(PropertyHint.NodeType, "CharacterBody3D")] private NodePath characterBodyPath;
    CharacterBody3D characterBody;

    [Export] private float accelerationTime = 0.5f;
    [Export] private float deccelerationTime = 0.5f;
    [Export] private float targetSpeed = 15.0f;
    [Export] private float maximumSpeed = 40.0f;

    [ExportSubgroup("Axis Lock")]
    [Export] private bool lockX = false;
    [Export] private bool lockY = false;
    [Export] private bool lockZ = false;

    private float maximumSpeedSquared = 0.0f;

    public override void _EntityReady()
    {
        IEntity owner = GetEntity();

        if (!GetComponentVariable(out desiredDirection)) return;

        characterBody = GetNode<CharacterBody3D>(characterBodyPath);

        maximumSpeedSquared = maximumSpeed * maximumSpeed;

        base._EntityReady();

    }

    protected override void _BehaviourPhysicsProcess(double delta)
    {

        Vector3 velocity = characterBody.Velocity;

        Vector3 desiredVelocity = desiredDirection.Direction * targetSpeed;
        if (lockX) desiredVelocity.X = velocity.X;
        if (lockY) desiredVelocity.Y = velocity.Y;
        if (lockZ) desiredVelocity.Z = velocity.Z;

        velocity = velocity.MoveToward(desiredVelocity, targetSpeed * (float)delta / (velocity.Length() > targetSpeed ? deccelerationTime : accelerationTime));

        if (velocity.LengthSquared() > maximumSpeedSquared) velocity = velocity.Normalized() * maximumSpeed;

        characterBody.Velocity = velocity;

    }

}

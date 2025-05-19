using Godot;

public partial class HLockedMovement : Behaviour
{

    private DesiredDirection desiredDirection;
    private CharacterBody3DData characterBodyData;

    [Export] private float accelerationTime = 0.5f;
    [Export] private float deccelerationTime = 0.5f;
    [Export] private float targetSpeed = 15.0f;
    [Export] private float maximumSpeed = 40.0f;

    private float maximumSpeedSquared = 0.0f;

    public override void _Ready(IEntity owner)
    {

        var components = owner.GetComponents();

        if (!GetComponentVariable("DesiredDirection", components, out desiredDirection)) return;
        if (!GetComponentVariable("CharacterBody3DData", components, out characterBodyData)) return;

        maximumSpeedSquared = maximumSpeed * maximumSpeed;

    }

    public override void _PhysicsProcess(double delta, IEntity owner)
    {

        Vector3 velocity = characterBodyData.Velocity;

        if (desiredDirection.Direction != Vector3.Zero) GD.Print(desiredDirection.Direction);

        velocity = velocity.MoveToward(desiredDirection.Direction * targetSpeed, targetSpeed * (float)delta / (velocity.Length() > targetSpeed ? deccelerationTime : accelerationTime));

        if (velocity.LengthSquared() > maximumSpeedSquared) velocity = velocity.Normalized() * maximumSpeed;

        characterBodyData.Velocity = velocity;

    }

}

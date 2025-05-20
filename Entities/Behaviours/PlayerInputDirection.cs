using Godot;

[GlobalClass]
public partial class PlayerInputDirection : Behaviour
{

    private CameraComponent cameraComponent;
    private DesiredDirection desiredDirection;
    Node3D cameraPivot;
    [Export] private float lerpPower = 1;

    public override void _EntityReady()
    {

        if (!GetComponentVariable(out desiredDirection)) return;
        if (!GetComponentVariable(out cameraComponent)) return;
        cameraPivot = GetNode<Node3D>(cameraComponent.CameraPivotPath);

        base._EntityReady();

    }

    protected override void _BehaviourProcess(double delta)
    {
        Vector2 inputDirection = Input.GetVector("movement.left", "movement.right", "movement.up", "movement.down");

        Vector3 targetDirection = inputDirection.X * cameraPivot.GlobalBasis.X + inputDirection.Y * cameraPivot.GlobalBasis.Z;

        desiredDirection.Direction = targetDirection;

    }

}

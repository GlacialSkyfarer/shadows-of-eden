using Godot;

[GlobalClass]
public partial class OTSCamera : Behaviour
{

    private const float CAMERA_MOVEMENT_MULT = 0.01f;

    private Node3D pivot;
    private SpringArm3D springArm;
    private Camera3D camera;

    private CameraComponent cameraComponent;

    private Vector2 cameraMovementInput = Vector2.Zero;

    private float xRotation = 0;
    private float yRotation = 0;

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion)
        {

            var mouseMotion = @event as InputEventMouseMotion;

            cameraMovementInput = -mouseMotion.Relative;

        }
    }

    public override void _EntityReady()
    {
        if (!GetComponentVariable<CameraComponent>(out cameraComponent)) return;
        pivot = GetNode<Node3D>(cameraComponent.CameraPivotPath);
        springArm = GetNode<SpringArm3D>(cameraComponent.CameraSpringArmPath);
        camera = GetNode<Camera3D>(cameraComponent.CameraPath);

        base._EntityReady();
    }

    protected override void _BehaviourProcess(double delta)
    {

        if (camera.Current) Input.MouseMode = cameraComponent.MouseModeWhileCurrent;

        yRotation = Mathf.PosMod(yRotation + cameraMovementInput.X * cameraComponent.HorizontalSensitivity * CAMERA_MOVEMENT_MULT, Mathf.Tau);
        xRotation = Mathf.Clamp(xRotation + cameraMovementInput.Y * cameraComponent.VerticalSensitivity * CAMERA_MOVEMENT_MULT,
                cameraComponent.XRotationClamp[0] / (360 / Mathf.Tau),
                cameraComponent.XRotationClamp[1] / (360 / Mathf.Tau));

        pivot.GlobalRotation = new(pivot.GlobalRotation.X, yRotation, pivot.GlobalRotation.Z);
        springArm.GlobalRotation = new(xRotation, springArm.GlobalRotation.Y, springArm.GlobalRotation.Z);

        springArm.SpringLength = cameraComponent.Zoom;

        cameraMovementInput = Vector2.Zero;
    }

}

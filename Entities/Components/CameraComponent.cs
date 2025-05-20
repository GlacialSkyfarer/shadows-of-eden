using Godot;

[GlobalClass]
public partial class CameraComponent : Component
{

    [Export] public NodePath CameraPath;
    [Export] public NodePath CameraPivotPath;
    [Export] public NodePath CameraSpringArmPath;

    [Export] public Input.MouseModeEnum MouseModeWhileCurrent = Input.MouseModeEnum.Captured;

    [Export] public float Zoom = 2.0f;
    [Export] public float HorizontalSensitivity = 1.0f;
    [Export] public float VerticalSensitivity = 1.0f;

    [Export] public float[] XRotationClamp = new float[2];

}

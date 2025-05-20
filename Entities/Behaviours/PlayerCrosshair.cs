using Godot;

[GlobalClass]
public partial class PlayerCrosshair : Behaviour
{

    private CrosshairComponent crosshairComponent;
    private AimPoint aimPoint;
    private MeshInstance3D crosshair;
    private RayCast3D raycast;

    public override void _EntityReady()
    {

        if (!GetComponentVariable<CrosshairComponent>(out crosshairComponent)) return;
        if (!GetComponentVariable<AimPoint>(out aimPoint)) return;

        crosshair = GetNode<MeshInstance3D>(crosshairComponent.CrosshairPath);
        raycast = GetNode<RayCast3D>(crosshairComponent.CastPath);

        base._EntityReady();

    }

    protected override void _BehaviourProcess(double delta)
    {

        raycast.TargetPosition = raycast.ToLocal(aimPoint.Target);
        raycast.ForceRaycastUpdate();

        if (raycast.IsColliding()) { crosshair.GlobalPosition = crosshair.GlobalPosition.Lerp(raycast.GetCollisionPoint(), (float)delta * 30f); }
        else
        { crosshair.GlobalPosition = crosshair.GlobalPosition.Lerp(raycast.ToGlobal(raycast.TargetPosition), (float)delta * 30f); }

    }

}

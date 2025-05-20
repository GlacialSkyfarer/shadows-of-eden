using Godot;

[GlobalClass]
public partial class RaycastAimPoint : Behaviour
{

    [Export] private NodePath castPath;
    private RayCast3D raycast;

    private AimPoint aimPoint;

    public override void _EntityReady()
    {

        if (!GetComponentVariable<AimPoint>(out aimPoint)) return;
        raycast = GetNode<RayCast3D>(castPath);

        base._EntityReady();

    }

    protected override void _BehaviourPhysicsProcess(double delta)
    {
        if (raycast.IsColliding()) { aimPoint.Target = raycast.GetCollisionPoint(); }
        else { aimPoint.Target = raycast.ToGlobal(raycast.TargetPosition); }
    }

}

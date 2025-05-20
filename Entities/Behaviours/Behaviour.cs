using Godot;

[Icon("res://Icons/icn_Behaviour.svg")]
public partial class Behaviour : Node
{

    [Export] public bool Enabled = true;
    protected bool Initialized = false;

    public virtual void _EntityReady() { Initialized = true; }

    protected virtual void _BehaviourProcess(double delta) { }
    protected virtual void _BehaviourPhysicsProcess(double delta) { }

    public override void _Process(double delta) { if (Initialized) _BehaviourProcess(delta); }
    public override void _PhysicsProcess(double delta) { if (Initialized) _BehaviourPhysicsProcess(delta); }

    public IEntity GetEntity()
    {
        Node owner = GetParentOrNull<Node>().GetParentOrNull<Node>();

        if (!(owner is IEntity)) return null;
        return owner as IEntity;
    }

    protected bool GetComponentVariable<T>(out T variable) where T : Component
    {

        T result = GetEntity().GetComponent<T>();

        if (result == null)
        {

            variable = null;
            GD.PrintErr("Component " + typeof(T).FullName + " not found. Disabling this behaviour.");
            Enabled = false;
            return false;

        }

        variable = result;

        return true;

    }

}

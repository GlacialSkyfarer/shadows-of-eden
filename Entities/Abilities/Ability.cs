using Godot;

[Icon("res://Icons/icn_Ability.svg")]
public partial class Ability : Node
{

    [Export] public bool Enabled = true;

    public virtual void _EntityReady() { }

    protected virtual void _Trigger() { }

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

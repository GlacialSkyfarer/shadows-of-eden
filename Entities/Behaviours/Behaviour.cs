using Godot;

public partial class Behaviour : Resource
{

    [Export] public bool Enabled = true;

    public Behaviour() { }

    protected bool GetComponentVariable<T>(string componentName, Godot.Collections.Dictionary<string, Component> components, out T variable) where T : Component
    {

        if (!components.ContainsKey(componentName) || components[componentName] == null)
        {

            variable = null;
            GD.PrintErr("Component " + componentName + " not found. Disabling this behaviour.");
            Enabled = false;
            return false;

        }

        variable = components[componentName] as T;

        return true;

    }


    public virtual void _Ready(IEntity owner) { }
    public virtual void _PhysicsProcess(double delta, IEntity owner) { }
    public virtual void _Process(double delta, IEntity owner) { }

}

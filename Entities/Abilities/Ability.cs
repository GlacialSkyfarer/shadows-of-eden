using Godot;

public partial class Ability : Resource
{

    [Export] public bool Enabled = true;

    public Ability() { }

    public void _Ready(IEntity owner) { }
    public void _Trigger(IEntity owner) { }

}

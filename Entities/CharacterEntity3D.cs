using Godot;
using Godot.Collections;

///A CharacterBody3D which implements the IEntity class and can make use of behaviours, abilities, and components.
[GlobalClass, Icon("res://Icons/icn_CharacterEntity3D.svg")]
public partial class CharacterEntity3D : CharacterBody3D, IEntity
{

    private Dictionary<string, Behaviour> _behaviours;
    private Dictionary<string, Ability> _abilities;
    private Dictionary<string, Component> _components;

    public Dictionary<string, Behaviour> GetBehaviours() { return this._behaviours; }
    public Dictionary<string, Ability> GetAbilities() { return this._abilities; }
    public Dictionary<string, Component> GetComponents() { return this._components; }

    public override void _Ready()
    {

        _behaviours = new();
        _abilities = new();
        _components = new();

        foreach (Behaviour b in GetNode("Behaviours").GetChildrenOfType<Behaviour>()) { _behaviours.Add(b.GetType().Name, b); }
        foreach (Ability a in GetNode("Abilities").GetChildrenOfType<Ability>()) { _abilities.Add(a.GetType().Name, a); }
        foreach (Component c in GetNode("Components").GetChildrenOfType<Component>()) { _components.Add(c.GetType().Name, c); }

        foreach (var b in _behaviours) { b.Value._EntityReady(); }
        foreach (var a in _abilities) { a.Value._EntityReady(); }

    }
    public override void _PhysicsProcess(double delta)
    {

        MoveAndSlide();

    }

}

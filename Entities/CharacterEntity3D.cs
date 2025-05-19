using Godot;
using Godot.Collections;

public partial class CharacterEntity3D : CharacterBody3D, IEntity
{

    [Export] private Dictionary<string, Behaviour> _behaviours;
    [Export] private Dictionary<string, Ability> _abilities;
    [Export] private Dictionary<string, Component> _components;

    public Dictionary<string, Behaviour> GetBehaviours() { return this._behaviours; }
    public void SetBehaviours(Dictionary<string, Behaviour> value) { this._behaviours = value; }
    public Dictionary<string, Ability> GetAbilities() { return this._abilities; }
    public void SetAbilities(Dictionary<string, Ability> value) { this._abilities = value; }
    public Dictionary<string, Component> GetComponents() { return this._components; }
    public void SetComponents(Dictionary<string, Component> value) { this._components = value; }

    CharacterBody3DData characterBody3DData = null;

    public override void _Ready()
    {

        if (_components.ContainsKey("CharacterBody3DData") && _components["CharacterBody3DData"] != null)
        {

            characterBody3DData = _components["CharacterBody3DData"] as CharacterBody3DData;

        }

        foreach (var b in _behaviours) { b.Value._Ready(this); }
        foreach (var a in _abilities) { a.Value._Ready(this); }

    }
    public override void _Process(double delta)
    {

        foreach (var b in _behaviours) { if (b.Value.Enabled) b.Value._Process(delta, this); }

    }
    public override void _PhysicsProcess(double delta)
    {


        if (characterBody3DData != null) characterBody3DData.Position = GlobalPosition;

        foreach (var b in _behaviours) { if (b.Value.Enabled) b.Value._PhysicsProcess(delta, this); }

        if (characterBody3DData != null)
        {

            Velocity = characterBody3DData.Velocity;
            GlobalPosition = characterBody3DData.Position;

            MoveAndSlide();

            characterBody3DData.Velocity = Velocity;
            characterBody3DData.Position = GlobalPosition;

        }


    }

}

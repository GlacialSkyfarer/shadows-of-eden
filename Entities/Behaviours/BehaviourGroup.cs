using Godot;
using Godot.Collections;
public partial class BehaviourGroup : Node {

    private Array<Behaviour> _behaviours;

    public override void _Ready()
    {

        _behaviours = Extensions.GetChildrenOfType<Behaviour>(this);

    }

    public void SetEnabled(bool value) {

        foreach (Behaviour b in _behaviours) {

            b.Enabled = value;

        }

    }

}
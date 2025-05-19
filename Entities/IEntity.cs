
using Godot.Collections;

public interface IEntity
{

    public void SetBehaviours(Dictionary<string, Behaviour> value);
    public Dictionary<string, Behaviour> GetBehaviours();
    public void SetAbilities(Dictionary<string, Ability> value);
    public Dictionary<string, Ability> GetAbilities();
    public void SetComponents(Dictionary<string, Component> value);
    public Dictionary<string, Component> GetComponents();

}

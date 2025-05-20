using Godot.Collections;
using Godot;

public interface IEntity
{

    public Dictionary<string, Behaviour> GetBehaviours();
    public Dictionary<string, Ability> GetAbilities();
    public Dictionary<string, Component> GetComponents();

    public T GetBehaviour<T>() where T : Behaviour
    {

        var behaviours = GetBehaviours();

        string typeName = typeof(T).FullName;

        if (behaviours.ContainsKey(typeName))
        {

            return behaviours[typeName] as T;

        }

        return null;

    }

    public T GetAbility<T>() where T : Ability
    {

        var abilities = GetAbilities();

        string typeName = typeof(T).FullName;

        if (abilities.ContainsKey(typeName))
        {

            return abilities[typeName] as T;

        }

        return null;

    }

    public T GetComponent<T>() where T : Component
    {

        var components = GetComponents();

        string typeName = typeof(T).FullName;

        if (components.ContainsKey(typeName))
        {

            return components[typeName] as T;

        }

        return null;

    }

}


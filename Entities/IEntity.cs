using Godot.Collections;
using Godot;

public interface IEntity 
{
    public static T GetComponentNode<T>(Node self, Node componentsContainer, string path) where T : Component {

        T component = componentsContainer.GetNode<T>(path);
        if (component == null) {

            GD.PrintErr($"Entity '{self.Name}' does not have a component named '{path}' and will be removed!");
            self.QueueFree();
            return null;

        }
        return component;

    }
}
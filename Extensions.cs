using Godot;

public static class Extensions
{

    public static Godot.Collections.Array<T> GetChildrenOfType<[MustBeVariant] T>(this Node n) where T : Node
    {

        Godot.Collections.Array<T> result = new();
        foreach (Node child in n.GetChildren())
        {

            if (child as T != null) result.Add(child as T);

        }

        return result;

    }

}

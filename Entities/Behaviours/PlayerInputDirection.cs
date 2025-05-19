using Godot;

public partial class PlayerInputDirection : Behaviour
{

    public override void _Process(double delta, IEntity owner)
    {

        DesiredDirection desiredDirection;

        var components = owner.GetComponents();
        if (!GetComponentVariable("DesiredDirection", components, out desiredDirection)) return;

        Vector2 inputDirection = new Vector2(
            (Input.IsKeyPressed(KeyMap.MOVEMENT.left) ? -1 : 0) + (Input.IsKeyPressed(KeyMap.MOVEMENT.right) ? 1 : 0),
            (Input.IsKeyPressed(KeyMap.MOVEMENT.up) ? -1 : 0) + (Input.IsKeyPressed(KeyMap.MOVEMENT.down) ? 1 : 0));

        Vector3 targetDirection = new Vector3(inputDirection.X, 0, inputDirection.Y).Normalized();

        desiredDirection.Direction = targetDirection;

    }

}

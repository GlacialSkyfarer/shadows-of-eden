using System;
using System.Text;
using System.Threading.Tasks;
using Godot;
using Godot.Collections;


public partial class PlayerEntity : CharacterBody3D, IEntity
{

    private enum State
    {
        Idle,
        Falling
    }

    [Flags] private enum ComponentsEnum
    {

        None = 0,
        PlayerWalk = 1 << 0,
        PlayerJump = 1 << 1

    }

    //CONSTANTS
    private const string COMPONENTS_CONTAINER_PATH = "Components";
    private const string PLAYER_WALK_PATH = "PlayerWalk";
    private const string PLAYER_JUMP_PATH = "PlayerJump";
    //_privateFields
    private State _currentState = State.Idle;
    private PlayerWalk _playerWalk;
    private PlayerJump _playerJump;
    private bool _isJumping = false;

    [Export] private Dictionary<State, ComponentsEnum> StateComponentDefinitions;
    //PublicFields

    public override void _Ready()
    {
        Node componentsContainer = GetNode<Node>(COMPONENTS_CONTAINER_PATH);
        if (componentsContainer == null)
        {
            GD.PrintErr($"Entity '{this.Name}' does not have a child named 'Components' and will be removed!");
            QueueFree();
            return;
        }
        _playerWalk = IEntity.GetComponentNode<PlayerWalk>(this, componentsContainer, PLAYER_WALK_PATH);
        _playerJump = IEntity.GetComponentNode<PlayerJump>(this, componentsContainer, PLAYER_JUMP_PATH);
    }

    public override void _Process(double delta)
    {

        ComponentsEnum currentlyEnabledComponents = StateComponentDefinitions[_currentState];

        _playerWalk.Enabled = currentlyEnabledComponents.HasFlag(ComponentsEnum.PlayerWalk);
        _playerJump.Enabled = currentlyEnabledComponents.HasFlag(ComponentsEnum.PlayerJump);

        switch (_currentState)
        {

            case State.Idle:

                if (!IsOnFloor())
                {
                    _currentState = State.Falling;
                }
                break;
            case State.Falling:
                if (IsOnFloor())
                {
                    _currentState = State.Idle;
                }
                if (Velocity.Y < 0)
                {
                    _isJumping = false;
                }
                break;
            default:
                break;

        }

        MoveAndSlide();

    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public Node _GetSelf() { return this; }

}
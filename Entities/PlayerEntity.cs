using Godot;
using Godot.Collections;

enum PlayerState {

    Idle,
    Falling

}

public partial class PlayerEntity : CharacterBody3D, IEntity {

    //CONSTANTS
    private const string BEHAVIOURS_CONTAINER_PATH = "Behaviours";
    private const string WALKING_GROUP_NAME = "Walking";
    private const string JUMPING_GROUP_NAME = "Jumping";
    //_privateFields
    private BehaviourGroup _walkingGroup;
    private BehaviourGroup _jumpingGroup;

    private PlayerState _currentState = PlayerState.Idle;
    private bool _isJumping = false;
    //PublicFields
    
    public override void _Ready()
    {
        Node behavioursContainer = GetNode<Node>(BEHAVIOURS_CONTAINER_PATH);
        if (behavioursContainer == null)
        {
            GD.PrintErr($"Entity '{this.Name}' does not have a child named 'Behaviours' and will be removed!");
            QueueFree();
            return;
        }

        _walkingGroup = GetBehaviourGroup(behavioursContainer, WALKING_GROUP_NAME);
        _jumpingGroup = GetBehaviourGroup(behavioursContainer, JUMPING_GROUP_NAME);
    }

    public override void _Process(double delta)
    {

        switch (_currentState) {

            case PlayerState.Idle: 

                if (!IsOnFloor()) {
                    _currentState = PlayerState.Falling;
                }
                break;
            case PlayerState.Falling:
                if (IsOnFloor()) {
                    _currentState = PlayerState.Idle;
                }
                if (Velocity.Y < 0) {
                    _isJumping = false;
                }
                break;
            default:
                break;

        }
    
    }

    private BehaviourGroup GetBehaviourGroup(Node parent, string name) {
    
        BehaviourGroup group = parent.GetNode<BehaviourGroup>(name);
        if (group == null) {

            GD.PrintErr($"Entity '{this.Name}' does not have required behaviour group '{name}' and will be removed!");
            QueueFree();

        }
        return group;
    }

}
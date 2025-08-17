using System;
using System.Runtime.CompilerServices;
using System.Timers;
using Godot;

public partial class PlayerWalk : Component {


    [Export] private NodePath _characterBodyPath;
    private CharacterBody3D _characterBody;
    private Vector2 _currentInput = Vector2.Zero;
    [Export] private float _walkingAcceleration = 14.0f;
    [Export] private float _airAccelerationMultiplier = 0.5f;
    [Export] private float _walkingSpeed = 7.5f;

    public override void _Ready()
    {
        base._Ready();
        _characterBody = GetNode<CharacterBody3D>(_characterBodyPath);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!Enabled) {
            _currentInput = Vector2.Zero;
            return;
        } 
        _currentInput = Input.GetVector(
            InputConstants.MOVEMENT_X_NEGATIVE, 
            InputConstants.MOVEMENT_X_POSITIVE, 
            InputConstants.MOVEMENT_Y_NEGATIVE, 
            InputConstants.MOVEMENT_Y_POSITIVE);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Vector3 velocity = _characterBody.Velocity;
        Vector3 desiredVelocity = _currentInput.X * Vector3.Right * _walkingSpeed + _currentInput.Y * Vector3.Back * _walkingSpeed;

        velocity = velocity.MoveToward(new Vector3(desiredVelocity.X, velocity.Y, desiredVelocity.Z), (float)delta * _walkingAcceleration);

        _characterBody.Velocity = velocity;

    }

}
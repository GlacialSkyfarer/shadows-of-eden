using Godot;
using System;

public partial class JumpAbility : Ability
{

    [Export] private NodePath characterBodyPath;
    private CharacterBody3D characterBody;
    [Export] private float jumpHeight = 3f;

    public void _Trigger() {


    }

}

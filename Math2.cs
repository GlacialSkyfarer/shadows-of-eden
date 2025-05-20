using System;
using Godot;

public static class Math2 {

	public static float JumpVelocity(float height, float gravity) {

		return Mathf.Sqrt((height * gravity) / 2);

	}

}

namespace PlatformerTest;

using Godot;


public partial class Player : CharacterBody2D {
  public const float SPEED = 200.0f;
  public const float JUMP_VELOCITY = -450.0f;

  public override void _PhysicsProcess(double delta) {
    var velocity = Velocity;

    // Add the gravity.
    if (!IsOnFloor()) {
      velocity += GetGravity() * (float)delta;
    }

    // Handle Jump.
    if (Input.IsActionJustPressed("ui_accept") && IsOnFloor()) {
      velocity.Y = JUMP_VELOCITY;
    }

    // Get the input direction and handle the movement/deceleration.
    // As good practice, you should replace UI actions with custom gameplay actions.
    var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
    if (direction != Vector2.Zero) {
      velocity.X = direction.X * SPEED;
    }
    else {
      velocity.X = Mathf.MoveToward(Velocity.X, 0, SPEED);
    }

    Velocity = velocity;
    MoveAndSlide();
  }
}

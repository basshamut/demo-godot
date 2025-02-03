using Godot;

public partial class Player : CharacterBody2D
{
	private const float Speed = 200.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsActionPressed("ui_right"))
			direction.X += 1;
		if (Input.IsActionPressed("ui_left"))
			direction.X -= 1;
		if (Input.IsActionPressed("ui_down"))
			direction.Y += 1;
		if (Input.IsActionPressed("ui_up"))
			direction.Y -= 1;

		Velocity = direction.Normalized() * Speed;
		MoveAndSlide();

		// Obtener el tamaño de la ventana del juego
		Vector2 viewportSize = GetViewportRect().Size;

		// Limitar la posición del personaje dentro de la ventana
		GlobalPosition = new Vector2(
			Mathf.Clamp(GlobalPosition.X, 0, viewportSize.X),
			Mathf.Clamp(GlobalPosition.Y, 0, viewportSize.Y)
		);
	}

}

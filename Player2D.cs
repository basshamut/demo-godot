using Godot;

namespace demogodot;

public partial class Player2D : CharacterBody2D
{
    private const float Speed = 300.0f;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Vector2.Zero;

        direction = Direction(direction);

        Velocity = direction.Normalized() * Speed;
        MoveAndSlide();

        // Obtener el tamaño de la ventana del juego
        Vector2 viewportSize = GetViewportRect().Size;

        // Limitar la posición dentro de la ventana sin sobrescribir MoveAndSlide()
        Position = new Vector2(
            Mathf.Clamp(Position.X, 0, viewportSize.X),
            Mathf.Clamp(Position.Y, 0, viewportSize.Y)
        );
    }

    private static Vector2 Direction(Vector2 direction)
    {
        direction.X += IsRightDirection() ? 1 : 0;
        direction.X -= IsLeftDirecction() ? 1 : 0;
        direction.Y += IsDownDirection() ? 1 : 0;
        direction.Y -= IsUpDirecction() ? 1 : 0;

        VerifyDirection();
        
        return direction;
    }

    private static void VerifyDirection()// Verificar si el código se ejecuta y la direccion
    {
        if (IsRightDirection())
        {
            GD.Print("Player2D _PhysicsProcess -> RIGHT");
        }

        if (IsLeftDirecction())
        {
            GD.Print("Player2D _PhysicsProcess -> LEFT");
        }

        if (IsDownDirection())
        {
            GD.Print("Player2D _PhysicsProcess -> DOWN");
        }

        if (IsUpDirecction())
        {
            GD.Print("Player2D _PhysicsProcess -> UP");
        }
    }

    private static bool IsUpDirecction()
    {
        return Input.IsActionPressed("ui_up");
    }

    private static bool IsDownDirection()
    {
        return Input.IsActionPressed("ui_down");
    }

    private static bool IsLeftDirecction()
    {
        return Input.IsActionPressed("ui_left");
    }

    private static bool IsRightDirection()
    {
        return Input.IsActionPressed("ui_right");
    }
}
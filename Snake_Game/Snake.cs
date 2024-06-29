using Raylib_CsLo;
using System.Numerics;

public class Snake
{
    private Vector2[] body;
    private const int speed = 3;
    private int size = 1;
    private Vector2 direction = new Vector2(0, 0);

    public Snake(Vector2 position)
    {
        this.body = new Vector2[255];
        this.body[0] = position;
    }

    public Vector2[] getbody()
    {
        return body;
    }

    public void updateSnake()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && direction.X != -speed)
        {
            direction.X = speed;
            direction.Y = 0;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && direction.X != speed)
        {
            direction.X = -speed;
            direction.Y = 0;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP) && direction.Y != speed)
        {
            direction.X = 0;
            direction.Y = -speed;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN) && direction.Y != -speed)
        {
            direction.X = 0;
            direction.Y = speed;
        }
        body[0] += direction;
    }

}

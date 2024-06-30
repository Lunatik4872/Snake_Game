using Raylib_CsLo;
using System.Numerics;

public class Snake
{
    private List<Vector2> body;
    private const int speed = 6;
    private int size = 1;
    private Vector2 direction = new Vector2(0, 0);
    private List<Vector2> positions = new List<Vector2>();
    private int score = 0;
    private int best_score = 0;

    public Snake(Vector2 position)
    {
        this.body = new List<Vector2>();
        this.body.Add(position);
    }

    public List<Vector2> getbody()
    {
        return body;
    }

    public int getSize()
    {
        return size;
    }

    public int getScore()
    {
        return score;
    }

    public void updateSnake(Fruit fruit, int fruitSize)
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

        positions.Insert(0, body[0]);

        if (direction.X != 0 || direction.Y != 0)
        {
            for (int i = 0; i < size; i++)
            {
                if (i < positions.Count)
                {
                    body[i] = positions[i];
                }
            }
        }

        body[0] += direction;

        if (positions.Count > size)
        {
            positions.RemoveAt(size);
        }

        if (eat(fruit, fruitSize))
        {
            grow(positions[size-1]);
            fruit.randomSpawn(body,fruitSize);
            score++;
        }
    }

    public void grow(Vector2 oldTailPosition)
    {
        size++;
        body.Add(oldTailPosition);
        positions.Add(oldTailPosition);
    }

    private Boolean eat(Fruit fruit, int fruitSize)
    {
        Vector2 fruitCoo = fruit.getPosition();
        return Math.Abs(body[0].X - fruitCoo.X) < fruitSize && Math.Abs(body[0].Y - fruitCoo.Y) < fruitSize; 
    }

}

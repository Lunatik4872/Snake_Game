using Raylib_CsLo;
using Raylib_CsLo.InternalHelpers;
using System.Numerics;

public class Snake
{
    private List<Vector2> body;
    private int speed = 5;
    private int size = 1;
    private Vector2 direction = new Vector2(0, 0);
    private List<Vector2> positions = new List<Vector2>();
    private int score = 0;
    private int bestScore = 0;

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
    public int getBestScore()
    {
        return bestScore;
    }

    public int getScore()
    {
        return score;
    }

    public int getSpeed()
    {
        return speed;
    }

    public Vector2 getDirection()
    {
        return direction;
    }

    public void setBestScore(int score)
    {
        this.bestScore = score;
    }

    public void setInit()
    {
        score = 0;
        direction = new Vector2(0, 0);
        positions = new List<Vector2>();
        body = new List<Vector2>();
        body.Add(new Vector2(100, 100));
        size = 1;
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

    public Boolean death()
    {
        float x = body[0].X;
        float y = body[0].Y;

        for (int i = 1; i < body.Count; i++)
        {
            if (body[i].X == x && body[i].Y == y)
            {
                return true;
            }
        }

        return x <= 40 || x >= 740 || y <= 40 || y >= 540;
    }

    public void speedUp()
    {
        if (speed < 10) speed++;
    }

    public void speedDown()
    {
        if (speed > 5) speed--;
    }
}


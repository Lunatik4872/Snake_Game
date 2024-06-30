using System.Linq;
using System.Numerics;

public class Fruit
{
    private Vector2 position;

    public Fruit() {}

    public Vector2 getPosition()
    {
        return position;
    }

    public void randomSpawn(List<Vector2> snake, int fruitSize)
    {
        Random rand = new Random();
        Vector2 fruitPosition;

        while (true)
        {
            int x = rand.Next(40 + fruitSize, 760 - fruitSize);
            int y = rand.Next(40 + fruitSize, 560 - fruitSize);
            fruitPosition = new Vector2(x, y);

            bool isOnSnake = false;
            foreach (Vector2 snakePart in snake)
            {
                if (Math.Abs(snakePart.X - fruitPosition.X) < fruitSize && Math.Abs(snakePart.Y - fruitPosition.Y) < fruitSize)
                {
                    isOnSnake = true;
                    break;
                }
            }

            if (!isOnSnake)
            {
                break;
            }
        }
        position = fruitPosition;
    }



}

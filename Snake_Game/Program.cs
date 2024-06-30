using Raylib_CsLo;
using System.Numerics;

public static class Program
{
    public static Task Main(string[] args)
    {
        Raylib.InitWindow(800, 600, "Snake_Game");
        Raylib.SetTargetFPS(60);


        Snake snake = new Snake(new Vector2(100,100));
        int bodySize = snake.getSize();
        Fruit fruit = new Fruit();
        fruit.randomSpawn(snake.getbody(), 20);


        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);
            Raylib.DrawText("Score : " + snake.getScore(), 10, 10, 30, Raylib.BLACK);

            for (int i = 0; i < bodySize; i++) Raylib.DrawRectangle(Convert.ToInt32(snake.getbody()[i].X), Convert.ToInt32(snake.getbody()[i].Y), 20, 20, Raylib.GREEN);
            Raylib.DrawRectangle(Convert.ToInt32(fruit.getPosition().X), Convert.ToInt32(fruit.getPosition().Y), 20, 20, Raylib.RED);
            snake.updateSnake(fruit,20);
            bodySize = snake.getSize();

            Raylib.EndDrawing();

        }

        Raylib.CloseWindow();

        return Task.CompletedTask;
    }
}
using Raylib_CsLo;
using System.Numerics;

public static class Program
{
    public static Task Main(string[] args)
    {
        Raylib.InitWindow(800, 600, "Snake_Game");
        Raylib.SetTargetFPS(30);


        Snake snake = new Snake(new Vector2(100,100));
        int bodySize = snake.getSize();


        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);

            for (int i = 0; i < bodySize; i++) Raylib.DrawRectangle(Convert.ToInt32(snake.getbody()[i].X), Convert.ToInt32(snake.getbody()[i].Y), 20, 20, Raylib.GREEN);
            snake.updateSnake();
            bodySize = snake.getSize();

            Raylib.EndDrawing();

        }

        Raylib.CloseWindow();

        return Task.CompletedTask;
    }
}
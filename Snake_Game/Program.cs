using Raylib_CsLo;
using System.Numerics;

public static class Program
{
    public static Task Main(string[] args)
    {
        Raylib.InitWindow(800, 600, "Snake_Game");
        Raylib.SetTargetFPS(60);


        Snake snake = new Snake(new Vector2(100,100));


        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);


            Raylib.DrawRectangle(Convert.ToInt32(snake.getbody()[0].X), Convert.ToInt32(snake.getbody()[0].Y), 30, 30, Raylib.GREEN);
            snake.updateSnake();

            Raylib.EndDrawing();

        }

        Raylib.CloseWindow();

        return Task.CompletedTask;
    }
}
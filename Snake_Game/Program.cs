using Raylib_CsLo;

public static class Program
{
    public static Task Main(string[] args)
    {
        Raylib.InitWindow(800, 600, "Snake_Game");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.RAYWHITE);
            Raylib.DrawText("C'est un beau test peut etre !", 10, 10, 30, Raylib.VIOLET);
            Raylib.EndDrawing();

        }

        Raylib.CloseWindow();

        return Task.CompletedTask;
    }
}
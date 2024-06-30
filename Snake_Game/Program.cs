using Raylib_CsLo;
using System.Numerics;

public static class Program
{
    private static void jouer(Snake snake)
    {
        snake.setInit();

        int bodySize = snake.getSize();
        Fruit fruit = new Fruit();
        fruit.randomSpawn(snake.getbody(), 20);


        while (!Raylib.WindowShouldClose())
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.LIME);
            Raylib.DrawRectangle(0, 0, 800, 40, Raylib.DARKGREEN);
            Raylib.DrawRectangle(0, 560, 800, 40, Raylib.DARKGREEN);
            Raylib.DrawRectangle(0, 0, 40, 600, Raylib.DARKGREEN);
            Raylib.DrawRectangle(760, 0, 40, 600, Raylib.DARKGREEN);

            Raylib.DrawText("Score : " + snake.getScore(), 10, 10, 20, Raylib.BLACK);
            Raylib.DrawText("Meilleur Score : " + snake.getBestScore(), 600, 10, 20, Raylib.BLACK);

            for (int i = 0; i < bodySize; i++) Raylib.DrawRectangle(Convert.ToInt32(snake.getbody()[i].X), Convert.ToInt32(snake.getbody()[i].Y), 20, 20, Raylib.DARKBLUE);
            Raylib.DrawRectangle(Convert.ToInt32(fruit.getPosition().X), Convert.ToInt32(fruit.getPosition().Y), 20, 20, Raylib.RED);
            snake.updateSnake(fruit, 20);
            bodySize = snake.getSize();

            if(snake.death())
            {
                gameOver(snake, fruit);
                return;
            }

            Raylib.EndDrawing();

        }
    }

    private static void menu(Snake snake)
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.LIME);
            Raylib.DrawRectangle(0, 0, 800, 40, Raylib.DARKGREEN);
            Raylib.DrawRectangle(0, 560, 800, 40, Raylib.DARKGREEN);
            Raylib.DrawRectangle(0, 0, 40, 600, Raylib.DARKGREEN);
            Raylib.DrawRectangle(760, 0, 40, 600, Raylib.DARKGREEN);

            Raylib.DrawText("SnakeGame", 280, 160, 40, Raylib.BLACK);
            Raylib.DrawText("Meilleur Score : " + snake.getBestScore(), 600, 10, 20, Raylib.BLACK);

            Raylib.DrawRectangle(320, 240, 140, 60, Raylib.GRAY);
            Raylib.DrawText("jouer", 350, 255, 30, Raylib.BLACK);

            if (Raylib.IsMouseButtonPressed(Raylib.MOUSE_LEFT_BUTTON) &&
                Raylib.GetMouseX() >= 320 && Raylib.GetMouseX() <= 460 &&
                Raylib.GetMouseY() >= 240 && Raylib.GetMouseY() <= 300)
            {
                jouer(snake);
                return;
            }

            Raylib.DrawRectangle(320, 330, 140, 60, Raylib.GRAY);
            Raylib.DrawText("Quitter", 340, 345, 30, Raylib.BLACK);

            if (Raylib.IsMouseButtonPressed(Raylib.MOUSE_LEFT_BUTTON) &&
                Raylib.GetMouseX() >= 320 && Raylib.GetMouseX() <= 460 &&
                Raylib.GetMouseY() >= 330 && Raylib.GetMouseY() <= 390)
            {
                return;
            }

            Raylib.EndDrawing();
        }
    }


    private static void gameOver(Snake snake, Fruit fruit)
    {
        if (snake.getScore() > snake.getBestScore()) snake.setBestScore(snake.getScore());

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.LIME);
            Raylib.DrawRectangle(0, 0, 800, 40, Raylib.DARKGREEN);
            Raylib.DrawRectangle(0, 560, 800, 40, Raylib.DARKGREEN);
            Raylib.DrawRectangle(0, 0, 40, 600, Raylib.DARKGREEN);
            Raylib.DrawRectangle(760, 0, 40, 600, Raylib.DARKGREEN);

            int bodySize = snake.getSize();

            for (int i = 0; i < bodySize; i++) Raylib.DrawRectangle(Convert.ToInt32(snake.getbody()[i].X), Convert.ToInt32(snake.getbody()[i].Y), 20, 20, Raylib.DARKBLUE);
            Raylib.DrawRectangle(Convert.ToInt32(fruit.getPosition().X), Convert.ToInt32(fruit.getPosition().Y), 20, 20, Raylib.RED);

            Raylib.DrawText("Game Over", 290, 160, 40, Raylib.BLACK);
            Raylib.DrawText("Meilleur Score : " + snake.getBestScore(), 600, 10, 20, Raylib.BLACK);
            Raylib.DrawText("Score : " + snake.getScore(), 10, 10, 20, Raylib.BLACK);

            Raylib.DrawRectangle(320, 240, 140, 60, Raylib.GRAY);
            Raylib.DrawText("ReJouer", 330, 255, 30, Raylib.BLACK);

            if (Raylib.IsMouseButtonPressed(Raylib.MOUSE_LEFT_BUTTON) &&
                Raylib.GetMouseX() >= 320 && Raylib.GetMouseX() <= 460 &&
                Raylib.GetMouseY() >= 240 && Raylib.GetMouseY() <= 300)
            {
                jouer(snake);
                return;
            }

            Raylib.DrawRectangle(320, 330, 140, 60, Raylib.GRAY);
            Raylib.DrawText("Quitter", 340, 345, 30, Raylib.BLACK);

            if (Raylib.IsMouseButtonPressed(Raylib.MOUSE_LEFT_BUTTON) &&
                Raylib.GetMouseX() >= 320 && Raylib.GetMouseX() <= 460 &&
                Raylib.GetMouseY() >= 330 && Raylib.GetMouseY() <= 390)
            {
                return;
            }

            Raylib.EndDrawing();
        }

    }

    public static Task Main(string[] args)
    {
        Raylib.InitWindow(800, 600, "Snake_Game");
        Raylib.SetTargetFPS(60);

        Snake snake = new Snake(new Vector2(100, 100));

        menu(snake);

        Raylib.CloseWindow();

        return Task.CompletedTask;
    }
}
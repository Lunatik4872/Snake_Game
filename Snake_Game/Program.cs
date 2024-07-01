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
            Raylib.DrawText("Vitesse : " + snake.getSpeed(), 340, 10, 20, Raylib.BLACK);

            for (int i = 0; i < bodySize; i++) Raylib.DrawRectangle(Convert.ToInt32(snake.getbody()[i].X), Convert.ToInt32(snake.getbody()[i].Y), 20, 20, Raylib.DARKBLUE);
            Raylib.DrawRectangle(Convert.ToInt32(fruit.getPosition().X), Convert.ToInt32(fruit.getPosition().Y), 20, 20, Raylib.RED);
            snake.updateSnake(fruit, 20);
            bodySize = snake.getSize();

            if (snake.death())
            {
                gameOver(snake, fruit);
                return;
            }

            if (snake.getDirection() == new Vector2(0, 0))
            {
                float thickness = 3;

                Raylib.DrawRectangle(649, 60, 30, 30, Raylib.GRAY);
                Raylib.DrawLineEx(new Vector2(665, 65), new Vector2(665, 85), thickness, Raylib.BLACK);
                Raylib.DrawLineEx(new Vector2(665, 65), new Vector2(655, 75), thickness, Raylib.BLACK);
                Raylib.DrawLineEx(new Vector2(664, 65), new Vector2(674, 75), thickness, Raylib.BLACK);

                Raylib.DrawRectangle(649, 95, 30, 30, Raylib.GRAY);
                Raylib.DrawLineEx(new Vector2(665, 100), new Vector2(665, 120), thickness, Raylib.BLACK);
                Raylib.DrawLineEx(new Vector2(665, 120), new Vector2(655, 110), thickness, Raylib.BLACK);
                Raylib.DrawLineEx(new Vector2(664, 120), new Vector2(674, 110), thickness, Raylib.BLACK);

                Raylib.DrawRectangle(684, 95, 30, 30, Raylib.GRAY);
                Raylib.DrawLineEx(new Vector2(689, 110), new Vector2(709, 110), thickness, Raylib.BLACK);
                Raylib.DrawLineEx(new Vector2(709, 111), new Vector2(699, 101), thickness, Raylib.BLACK);
                Raylib.DrawLineEx(new Vector2(709, 109), new Vector2(699, 119), thickness, Raylib.BLACK);

                Raylib.DrawRectangle(614, 95, 30, 30, Raylib.GRAY);
                Raylib.DrawLineEx(new Vector2(619, 110), new Vector2(639, 110), thickness, Raylib.BLACK);
                Raylib.DrawLineEx(new Vector2(619, 111), new Vector2(629, 101), thickness, Raylib.BLACK);
                Raylib.DrawLineEx(new Vector2(619, 109), new Vector2(629, 119), thickness, Raylib.BLACK);
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
            Raylib.DrawText("Vitesse : " + snake.getSpeed(), 340, 10, 20, Raylib.BLACK);

            Raylib.DrawRectangle(465, 10, 20, 20, Raylib.GRAY);
            Raylib.DrawText(">", 470, 7, 30, Raylib.BLACK);
            if (Raylib.IsMouseButtonPressed(Raylib.MOUSE_LEFT_BUTTON) &&
                Raylib.GetMouseX() >= 465 && Raylib.GetMouseX() <= 485 &&
                Raylib.GetMouseY() >= 10 && Raylib.GetMouseY() <= 30)
            {
                snake.speedUp();
            }

            Raylib.DrawRectangle(302, 10, 20, 20, Raylib.GRAY);
            Raylib.DrawText("<", 307, 7, 30, Raylib.BLACK);
            if (Raylib.IsMouseButtonPressed(Raylib.MOUSE_LEFT_BUTTON) &&
                Raylib.GetMouseX() >= 302 && Raylib.GetMouseX() <= 422 &&
                Raylib.GetMouseY() >= 10 && Raylib.GetMouseY() <= 30)
            {
                snake.speedDown();
            }

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
            Raylib.DrawText("Vitesse : " + snake.getSpeed(), 340, 10, 20, Raylib.BLACK);

            Raylib.DrawRectangle(465, 10, 20, 20, Raylib.GRAY);
            Raylib.DrawText(">", 470, 7, 30, Raylib.BLACK);
            if (Raylib.IsMouseButtonPressed(Raylib.MOUSE_LEFT_BUTTON) &&
                Raylib.GetMouseX() >= 465 && Raylib.GetMouseX() <= 485 &&
                Raylib.GetMouseY() >= 10 && Raylib.GetMouseY() <= 30)
            {
                snake.speedUp();
            }

            Raylib.DrawRectangle(302, 10, 20, 20, Raylib.GRAY);
            Raylib.DrawText("<", 307, 7, 30, Raylib.BLACK);
            if (Raylib.IsMouseButtonPressed(Raylib.MOUSE_LEFT_BUTTON) &&
                Raylib.GetMouseX() >= 302 && Raylib.GetMouseX() <= 422 &&
                Raylib.GetMouseY() >= 10 && Raylib.GetMouseY() <= 30)
            {
                snake.speedDown();
            }

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
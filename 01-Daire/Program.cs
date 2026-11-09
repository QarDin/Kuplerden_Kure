using System.Numerics;
using Raylib_cs;

Raylib.SetTargetFPS(60);
Camera3D cam = new Camera3D();
cam.Position = new Vector3(0.0f, 10.0f, 30.0f);
cam.Target = new Vector3(0.0f, 0.0f, 0.0f);
cam.Up = new Vector3(0.0f, 0.1f, 0.0f);
cam.FovY = 60.0f;
cam.Projection = CameraProjection.Perspective;
int cetvel = 12 / 2;
Vector3 vec = new Vector3();
vec.X = 0;
vec.Y = 0;
vec.Z = 0;
Raylib.InitWindow(1920, 1080, "KuplerdenKure");
while (!Raylib.WindowShouldClose())
{
    vec.X = 0;
    vec.Y = 0;
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    Raylib.BeginMode3D(cam);
    for (int i = -6; i <= cetvel; i += 2)
    {
        vec.X = i;

        for (int y = -6; y <= cetvel; y += 2)
        {
            vec.Y = y;
            for (int z = -6; z <= cetvel; z += 2)
            {
                vec.Z = z;
                double d = Math.Sqrt((i * i) + (y * y));
                if (d <= cetvel && y == 0)   // daire: yalnız z = 0 katmanı
                {
                    Raylib.DrawCube(vec, 2, 2, 2, Color.Blue);
                }

            }
            // if (vec.X == 0 || vec.Y == 0)
            // {
            //     Raylib.DrawCube(vec, 2, 2, 2, Color.Blue);

            // }
        }

    }
    Raylib.EndMode3D();
    Raylib.EndDrawing();

}
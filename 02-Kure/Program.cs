using System.Numerics;
using Raylib_cs;

Raylib.SetTargetFPS(60);
Camera3D cam = new Camera3D();
cam.Position = new Vector3(0.0f, 10.0f, 900.0f);
cam.Target = new Vector3(0.0f, 0.0f, 0.0f);
cam.Up = new Vector3(0.0f, 1.0f, 0.0f);
cam.FovY = 60.0f;
cam.Projection = CameraProjection.Perspective;
int cetvel = 196 / 2;
Vector3 vec = new Vector3();
vec.X = 0;
vec.Y = 0;
vec.Z = 0;
Raylib.InitWindow(1920, 1080, "KuplerdenKure");
Raylib.DisableCursor();
List<Vector3> CubePos = new List<Vector3>();
for (int i = -cetvel; i <= cetvel; i += 2)
{
    vec.X = i;

    for (int y = -cetvel; y <= cetvel; y += 2)
    {
        vec.Y = y;
        for (int z = -cetvel; z <= cetvel; z += 2)
        {
            vec.Z = z;
            double d = Math.Sqrt((i * i) + (y * y) + (z * z));
            if (d <= cetvel)
            {

                //hayatimda yazdigim en acayip kod idi bu

                // if (cetvel < Math.Sqrt(((i + 2) * (i + 2)) + (y * y) + (z * z)) || cetvel < Math.Sqrt(((i - 2) * (i - 2)) + (y * y) + (z * z)) || cetvel < Math.Sqrt((i * i) + ((y + 2) * (y + 2)) + (z * z)) || cetvel < Math.Sqrt((i * i) + ((y - 2) * (y - 2)) + (z * z)) || cetvel < Math.Sqrt((i * i) + (y * y) + ((z + 2) * (z + 2))) || cetvel < Math.Sqrt((i * i) + (y * y) + ((z - 2) * (z - 2))))
                // {
                CubePos.Add(vec);
                //}
            }
            // if (d <= cetvel)
            // {
            // }

        }
        // if (vec.X == 0 || vec.Y == 0)
        // {
        //     Raylib.DrawCube(vec, 2, 2, 2, Color.Blue);

        // }
    }

}

while (!Raylib.WindowShouldClose())
{
    vec.X = 0;
    vec.Y = 0;
    // Kamera: WASD ileri/geri/yan, Bosluk yukari, Shift asagi, fare bakis
    float hiz = 300.0f * Raylib.GetFrameTime();
    float ileri = (Raylib.IsKeyDown(KeyboardKey.W) ? 1 : 0) - (Raylib.IsKeyDown(KeyboardKey.S) ? 1 : 0);
    float yan = (Raylib.IsKeyDown(KeyboardKey.D) ? 1 : 0) - (Raylib.IsKeyDown(KeyboardKey.A) ? 1 : 0);
    float yukari = (Raylib.IsKeyDown(KeyboardKey.Space) ? 1 : 0) - (Raylib.IsKeyDown(KeyboardKey.LeftShift) ? 1 : 0);
    Vector2 fare = Raylib.GetMouseDelta();
    Raylib.UpdateCameraPro(ref cam, new Vector3(ileri * hiz, yan * hiz, yukari * hiz), new Vector3(fare.X * 0.006f, fare.Y * 0.006f, 0.0f), 0.0f);
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    Raylib.BeginMode3D(cam);
    for (int i = 0; i < CubePos.Count; i++)
    {
        Color color = new Color(0, (int)((CubePos[i].Z + cetvel) * 255f / (2 * cetvel)), (int)((CubePos[i].Y + cetvel) * 255f / (2 * cetvel)));
        Raylib.DrawCube(CubePos[i], 2, 2, 2, color);
        Raylib.DrawCubeWires(CubePos[i], 2, 2, 2, Color.Blue);
    }

    Raylib.EndMode3D();
    Raylib.DrawFPS(50, 50);
    Raylib.DrawText($"Cetvel olcusu = {cetvel}", 50, 70, 20, Color.RayWhite);
    Raylib.DrawText($"Kup Sayisi = {CubePos.Count}", 50, 90, 20, Color.DarkGreen);
    Raylib.EndDrawing();

}
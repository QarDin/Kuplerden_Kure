using System.Numerics;
using Raylib_cs;

// KupUret'in tuşlu hali (8 Kas): F = dolu küre / yalnız kabuk, H = yarım küre (Y > 0 çizilmez, içi görünür)
Raylib.SetTargetFPS(60);
Camera3D cam = new Camera3D();
cam.Position = new Vector3(0.0f, 10.0f, 900.0f);
cam.Target = new Vector3(0.0f, 0.0f, 0.0f);
cam.Up = new Vector3(0.0f, 1.0f, 0.0f);
cam.FovY = 60.0f;
cam.Projection = CameraProjection.Perspective;
int cetvel = 196 / 2;
Raylib.InitWindow(1920, 1080, "KuplerdenKure");
Raylib.DisableCursor();

// Bir konum kürenin içinde mi (merkeze uzaklık <= cetvel)
bool Icinde(int x, int y, int z) => Math.Sqrt((x * x) + (y * y) + (z * z)) <= cetvel;

List<Vector3> Dolu = new List<Vector3>();   // içindeki bütün küpler
List<Vector3> Kabuk = new List<Vector3>();  // altı komşudan biri dışarıda olanlar (yüzey)
for (int x = -cetvel; x <= cetvel; x += 2)
{
    for (int y = -cetvel; y <= cetvel; y += 2)
    {
        for (int z = -cetvel; z <= cetvel; z += 2)
        {
            if (!Icinde(x, y, z)) continue;
            Vector3 p = new Vector3(x, y, z);
            Dolu.Add(p);
            if (!Icinde(x + 2, y, z) || !Icinde(x - 2, y, z) || !Icinde(x, y + 2, z) || !Icinde(x, y - 2, z) || !Icinde(x, y, z + 2) || !Icinde(x, y, z - 2))
            {
                Kabuk.Add(p);
            }
        }
    }
}

bool doluMod = false;
bool yarim = false;

while (!Raylib.WindowShouldClose())
{
    if (Raylib.IsKeyPressed(KeyboardKey.F)) doluMod = !doluMod;
    if (Raylib.IsKeyPressed(KeyboardKey.H)) yarim = !yarim;

    // Kamera: WASD ileri/geri/yan, Bosluk yukari, Shift asagi, fare bakis
    float hiz = 300.0f * Raylib.GetFrameTime();
    float ileri = (Raylib.IsKeyDown(KeyboardKey.W) ? 1 : 0) - (Raylib.IsKeyDown(KeyboardKey.S) ? 1 : 0);
    float yan = (Raylib.IsKeyDown(KeyboardKey.D) ? 1 : 0) - (Raylib.IsKeyDown(KeyboardKey.A) ? 1 : 0);
    float yukari = (Raylib.IsKeyDown(KeyboardKey.Space) ? 1 : 0) - (Raylib.IsKeyDown(KeyboardKey.LeftShift) ? 1 : 0);
    Vector2 fare = Raylib.GetMouseDelta();
    Raylib.UpdateCameraPro(ref cam, new Vector3(ileri * hiz, yan * hiz, yukari * hiz), new Vector3(fare.X * 0.05f, fare.Y * 0.05f, 0.0f), 0.0f);

    List<Vector3> liste = doluMod ? Dolu : Kabuk;
    int cizilen = 0;
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    Raylib.BeginMode3D(cam);
    for (int i = 0; i < liste.Count; i++)
    {
        if (yarim && liste[i].Y > 0) continue;   // yarım küre: üst yarıyı çizme
        Color color = new Color(0, (int)((liste[i].Z + cetvel) * 255f / (2 * cetvel)), (int)((liste[i].Y + cetvel) * 255f / (2 * cetvel)));
        Raylib.DrawCube(liste[i], 2, 2, 2, color);
        Raylib.DrawCubeWires(liste[i], 2, 2, 2, Color.Blue);
        cizilen++;
    }
    Raylib.EndMode3D();
    Raylib.DrawFPS(50, 50);
    Raylib.DrawText($"Cetvel olcusu = {cetvel}", 50, 70, 20, Color.RayWhite);
    Raylib.DrawText($"Mod = {(doluMod ? "DOLU" : "KABUK")} | Yarim = {(yarim ? "evet" : "hayir")} | Cizilen kup = {cizilen}", 50, 90, 20, Color.DarkGreen);
    Raylib.DrawText("F: dolu/kabuk   H: yarim kure", 50, 110, 20, Color.Gray);
    Raylib.EndDrawing();
}
Raylib.CloseWindow();

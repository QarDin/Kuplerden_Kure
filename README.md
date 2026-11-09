# Kuplerden_Kure

Sadece **C#** ve **raylib** (Raylib-cs) kullanarak küplerden pürüzsüze yakın bir küre çizme denemesi.

Videosu: https://youtu.be/9okjSGXc-TQ

Videoda anlattığım aşamalar üç klasörde duruyor:

| Klasör | Ne yapar |
|---|---|
| `01-Daire` | Önce küre değil daire: merkeze uzaklığı yarıçaptan küçük olan küpleri çiziyor (cetvel 12 cm, yarıçap 6). |
| `02-Kure` | Üçüncü boyut eklendi, cetvel 98'e çıktı: yaklaşık 490.000 küp, eksene göre renk (`new Color(0, z, y)`), `DrawCubeWires` ile çerçeve. FPS çok düşüyor. |
| `03-Kabuk-ve-Yarim` | Yalnız yüzeydeki küpleri çiziyor (altı komşusundan biri boşsa yüzeydir): yaklaşık 24.700 küp. `F` dolu/kabuk, `H` yarım küre. |

## Çalıştırma

[.NET 10 SDK](https://dotnet.microsoft.com/download) gerekiyor (proje `net10.0`, paket `Raylib-cs 8.1.0`).

```bash
cd 03-Kabuk-ve-Yarim
dotnet run
```

Kontroller (`02` ve `03`): `W A S D` hareket, `Boşluk` yukarı, `Shift` aşağı, fare bakış, `Esc` çıkış. `01-Daire`'de kamera sabit.

## Not

`02-Kure` bilerek optimize edilmemiş sürüm: videodaki "yarım milyon küp ve 3 FPS" anı bu. İçinde yorum satırına alınmış ilk komşu kontrolü denemem de duruyor.

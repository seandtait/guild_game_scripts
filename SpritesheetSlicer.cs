using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesheetSlicer : MonoBehaviour
{
    public static SpritesheetSlicer instance;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
        } else
        {
            instance = this;
        }
    }

    int pixelsPerUnit = 16;

    public Sprite[,] Slice(Sprite _spriteSheet, int rows, int columns)
    {
        Sprite spriteSheet = _spriteSheet;
        spriteSheet.texture.filterMode = FilterMode.Point;
        Sprite[,] TileSprites = new Sprite[columns, rows];
        int spriteWidth = _spriteSheet.texture.width / columns;
        int spriteHeight = _spriteSheet.texture.height / rows;
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Rect frameArea = new Rect(x * spriteWidth, y * spriteHeight, spriteWidth, spriteHeight);
                Sprite frame = Sprite.Create(_spriteSheet.texture, frameArea, Vector2.zero, pixelsPerUnit);
                TileSprites[x, y] = frame;

            }
        }
        return TileSprites;
    }

}

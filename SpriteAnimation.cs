using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    // Public
    public Sprite spriteSheet;
    public float speed;

    // Private
    Sprite[,] TileSprites;
    int columns = 3;
    int rows = 4;
    SpriteRenderer sr;
    Direction direction;

    // Animation
    public float currentDeltaCount = 0;
    public bool animated = true; // False if the sprite will never be animated
    bool animate = false; // Whether to animate or not
    bool reverse = false; // Whether the animation is playing forward or backwards
    int defaultFrame = 1;
    public int currentFrame = 1;


    public void Animate(bool _value = true)
    {
        animate = _value;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        direction = GetComponent<Direction>();

        TileSprites = SpritesheetSlicer.instance.Slice(spriteSheet, rows, columns);
        currentFrame = defaultFrame;
        SetSprite();
        animate = true;
    }

    void SetSprite()
    {
        sr.sprite = TileSprites[currentFrame, (int)direction.value];
    }

    private void Update()
    {
        if (!animated)
        {
            return;
        }

        if(animate)
        {
            UpdateAnimation();
        }
        if (!animate)
        {
            currentFrame = defaultFrame;
            direction.value = Directions.SOUTH;
            SetSprite();
        }
    }

    void UpdateAnimation()
    {
        currentDeltaCount += Time.deltaTime;
        if (currentDeltaCount >= speed)
        {
            currentDeltaCount = 0;
            NextFrame();
        }
    }

    void NextFrame()
    {
        if (reverse)
        {
            currentFrame -= 1;
        } else
        {
            currentFrame += 1;
        }

        if (currentFrame >= columns)
        {
            currentFrame = columns - 2;
            reverse = true;
        }
        if (currentFrame < 0)
        {
            currentFrame = 1;
            reverse = false;
        }

        SetSprite();
    }


}

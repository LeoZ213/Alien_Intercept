using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public float hp = 100f;
    public SpriteRenderer spriteRenderer;
    public Sprite damagedSprite;
    public void updateSprite()
    {
        if (hp == 100) {
            spriteRenderer.sprite = damagedSprite;
        }
    }
}

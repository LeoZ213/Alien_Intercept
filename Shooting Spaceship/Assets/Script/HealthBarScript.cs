using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public float hp = 100f;
    public SpriteRenderer spriteRenderer;
    public Sprite damagedSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateSprite()
    {
        if (hp == 100) {
            spriteRenderer.sprite = damagedSprite;
        }
    }
}

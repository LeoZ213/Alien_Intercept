using UnityEngine;

public class AdjustColliderSize : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D laserCollider;
    public Bounds oldSpriteBounds;
    public Sprite oldSprite;
    public Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the sprite for the first frame
        oldSprite = spriteRenderer.sprite;
        oldSpriteBounds = spriteRenderer.sprite.bounds;
        originalPosition = laserCollider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for the new frame
        Bounds newSpriteBounds = spriteRenderer.sprite.bounds;
        Sprite newSprite = spriteRenderer.sprite;
        //Determines if the sprite has changed and changes the collider size based on the new sprite
        if (newSprite != oldSprite)
        {
            laserCollider.size = new Vector2(newSpriteBounds.size.x, newSpriteBounds.size.y);
            laserCollider.offset = new Vector2(laserCollider.offset.x, laserCollider.offset.y - (newSpriteBounds.size.y - oldSpriteBounds.size.y) / 2);
        }
        //Sets the current frame as the old sprite
        oldSprite = newSprite;
        oldSpriteBounds = newSpriteBounds;
    }
}

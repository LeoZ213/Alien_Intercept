using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public Boundaries boundary;
    private float boundaryWidth;
    private float boundaryHeight;

    private float xOffset;
    private float yOffset;

    private PolygonCollider2D bossCollider;

    public Animator teleport;
    public float teleportTime = 1f;
    private float timer = 0f;
    private float teleportInterval = 5f;

    public bool teleportStarted {  get; private set; }

    //Initializations
    void Start()
    {
        boundary = FindObjectOfType<Boundaries>();
        boundaryWidth = boundary.screenBounds.x;
        boundaryHeight = boundary.screenBounds.y;
        bossCollider = gameObject.GetComponent<PolygonCollider2D>();
        teleportStarted = false;
    }
     void Update()
    {
        //Having a timer to determine when teleport skill should be activated
        timer = timer + Time.deltaTime;
        if (timer > teleportInterval)
        {
            StartCoroutine(TeleportBoss());
            timer = 0;
        }
    }

    IEnumerator TeleportBoss()
    {
        teleportStarted = true;
        teleport.SetTrigger("Teleport");
        yield return new WaitForSeconds(teleportTime);
        RandomTeleport();
        teleport.SetTrigger("Default");
        teleportStarted = false;
    }
    void RandomTeleport()
    {
        //Takes the screenboudns to calculate a reasonable offset value
        xOffset = Random.Range(boundaryWidth/ 2, boundaryWidth / 2 * -1);
        yOffset = Random.Range(boundaryHeight / 2, boundaryHeight / 2 * -1);

        // Keep generating new offsets until a valid position is found
        while ((bossCollider.transform.position.y + yOffset + (bossCollider.bounds.size.y / 2)) <= 0)
        {
            xOffset = Random.Range(-boundaryWidth / 2, boundaryWidth / 2);
            yOffset = Random.Range(-boundaryHeight / 2, boundaryHeight / 2);
        }

        // Set the new position of the boss
        gameObject.transform.position = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);
    }
}


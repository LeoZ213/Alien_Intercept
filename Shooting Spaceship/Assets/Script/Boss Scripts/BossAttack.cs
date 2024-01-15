using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    
    public Collider2D bossCollider;

    [Header("Laser Components")]
    public int numCollidersHit;
    public GameObject laser;
    private RaycastHit2D[] hits = new RaycastHit2D[1];
    private Animator laserAnimator;
    private SpriteRenderer laserRenderer;

    [Header("Other Scripts")]
    public BossMovement bossMovement;
    public SpawnAliens spawnAlienScript;

    [Header("Enemy Prefabs")]
    public GameObject[] enemies = new GameObject[2];


    [Header("Boolean Values")]
    private bool spawnStarted = false;
    private bool powerupSpawned = false;
    private bool laserStarted = false;

    [Header("Powerup Prefabs")]
    public GameObject[] powerups = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        bossCollider = GetComponent<Collider2D>();
        laserAnimator = laser.GetComponent<Animator>();
        laserRenderer = laser.GetComponent<SpriteRenderer>();
        Debug.Log(transform.position);
    }

    void Update()
    {
        if (spawnStarted == false)
        {
            Debug.Log("Started spawning aliens");
            int amount = Random.Range(1, 5);
            StartCoroutine(SpawnAliens(amount));
        }
        if (powerupSpawned == false)
        {
            StartCoroutine(SpawnPowerups());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        numCollidersHit = bossCollider.Raycast(Vector2.down, hits,Mathf.Infinity, ~3);
        if (hits[0].collider != null && laserStarted == false && bossMovement.teleportStarted == false) {
            Debug.DrawRay(gameObject.transform.position, Vector2.down, Color.yellow);
            Debug.Log("Started laser");
            StartCoroutine(ShootLaser());
        }
        hits[0] = default;
    }

    IEnumerator ShootLaser()
    {
        yield return new WaitForSeconds(0.5f);
        EnableLaserComponents();
        yield return new WaitForSeconds(1);
        DisableLaserComponents();
    }
    IEnumerator SpawnAliens(int amount)
    {
        spawnStarted = true;
        int index = Random.Range(0, enemies.Length - 1);
        float yVariability = Random.Range(0, 4);
        GameObject clonedEnemy = Instantiate(enemies[index], 
            new Vector3(transform.position.x, transform.position.y - yVariability, transform.position.z), Quaternion.identity);
        spawnAlienScript.SpawnAlienSpaceship(clonedEnemy, Quaternion.identity, amount);
        yield return new WaitForSeconds(10f);
        spawnStarted = false;
    }
    IEnumerator SpawnPowerups()
    {
        powerupSpawned = true;
        int index = Random.Range(0, powerups.Length - 1);
        Instantiate(powerups[index],gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(10f);
        powerupSpawned = false;
    }
    void EnableLaserComponents()
    {
        laserStarted = true;
        laser.gameObject.SetActive(true);
        laserRenderer.enabled = true;
        laserAnimator.enabled = true;
    }
    private void DisableLaserComponents()
    {
        laserStarted = false;
        laser.gameObject.SetActive(false);
        laserRenderer.enabled = false;
        laserAnimator.enabled = false;
        laserStarted = false;
    }
}

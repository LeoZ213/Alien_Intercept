
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{
    public GameObject referenceObject;
    public Quaternion spawnRotation = Quaternion.identity;
    public int maxSpawnCount = 5;
    public Collider2D colliderObject;
    private float colliderWidth;
    private float colliderHeight;

    // Start is called before the first frame update
    void Start()
    {
        colliderWidth = colliderObject.GetComponent<Collider2D>().bounds.size.x;
        colliderHeight = colliderObject.GetComponent<Collider2D>().bounds.size.y;
        Debug.Log(colliderWidth);
        Debug.Log("spawn position" + referenceObject.transform.position.x);
        SpawnAlienSpaceship(referenceObject, spawnRotation);
    }
    void SpawnAlienSpaceship(GameObject alien, Quaternion rotation)
    {
        int spawnCount = 0;
        Vector2 spawnPosition = referenceObject.transform.position;

        if (referenceObject != null)
        {
            while (spawnCount < maxSpawnCount)
            {
                spawnPosition.x += colliderWidth + 0.25f;
                Debug.Log("NEW SPAWN POSITION" + spawnPosition.x);
                GameObject alienInstance = Instantiate(referenceObject, spawnPosition, rotation);
                spawnCount++;
            }
        }
        else
        {
            Debug.Log("Prefab reference is null. Please assign the Alien Spaceship prefab in the Inspector.");
        }
    }
}

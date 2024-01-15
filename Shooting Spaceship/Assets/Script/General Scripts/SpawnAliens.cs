
using UnityEngine;

public class SpawnAliens : MonoBehaviour
{
    public GameObject referenceObject;
    public Quaternion spawnRotation = Quaternion.identity;
    public int maxSpawnCount = 5;
    public Collider2D colliderObject;
    private float colliderWidth;

    // Start is called before the first frame update
    void Start()
    {
        colliderWidth = colliderObject.GetComponent<Collider2D>().bounds.size.x;
        SpawnAlienSpaceship(referenceObject, spawnRotation, maxSpawnCount);
    }
    public void SpawnAlienSpaceship(GameObject alien, Quaternion rotation, int maxSpawnCount)
    {
        //Keeps track of the spawn count and the initial position
        int spawnCount = 0;
        Vector2 spawnPosition = referenceObject.transform.position;

        //Checks if the gameObject exists
        if (referenceObject != null)
        {
            while (spawnCount < maxSpawnCount)
            {
                spawnPosition.x += colliderWidth + 0.25f;
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

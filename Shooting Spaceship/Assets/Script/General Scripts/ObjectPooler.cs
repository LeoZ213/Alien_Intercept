using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;            // Identifier for the pool.
        public GameObject prefab;     // The prefab of objects to be pooled.
        public int size;              // Initial size of the object pool.
    }

    #region Singleton
    public static ObjectPooler Instance;  // Singleton instance for ObjectPooler.

    private void Awake()
    {
        Instance = this;  // Assign the current instance as the singleton instance.
    }
    #endregion

    public List<Pool> pools;                // List of object pools defined in the Inspector.
    public Dictionary<string, Queue<GameObject>> poolDictionary;  // Dictionary to store object pools.

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();  // Initialize the dictionary.

        // Loop through each pool defined in the Inspector.
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // Instantiate and enqueue objects to create the initial object pool.
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            // Add the object pool to the dictionary with its tag as the key.
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            // Log a warning if the requested pool tag doesn't exist.
            Debug.LogWarning(new Exception("Pool with tag " + tag + " doesn't exist"));
            return null;
        }

        // Dequeue an object from the specified pool.
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        // Activate and set the position and rotation of the spawned object.
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        // Check if the spawned object implements the IPooledObject interface and call OnObjectSpawn if so.
        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        // Start a coroutine to enqueue the object back into the pool after a delay.
        StartCoroutine(DelayedEnqueue(tag, objectToSpawn, 5));

        // Return the spawned object.
        return objectToSpawn;
    }

    private IEnumerator DelayedEnqueue(string tag, GameObject obj, int delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified delay in seconds.

        // Enqueue the object back into the pool.
        poolDictionary[tag].Enqueue(obj);
    }
}

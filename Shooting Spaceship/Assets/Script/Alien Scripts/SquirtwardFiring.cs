using UnityEngine;

public class SquirtwardFiring : MonoBehaviour
{
    ObjectPooler objectPooler;
    public float fireRate = 1f;
    private float nextFireTime = 0.0f;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; //Updates the next allowed firing time
            objectPooler.SpawnFromPool("SquirtwardSplash", new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public Transform target;

    private Rigidbody2D rb;

    public float speed =10f;

    public float rotateSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Fixed Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2) target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, -transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
        
        rb.velocity = -transform.up * speed;
    }
}

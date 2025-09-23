using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float speed = 10f;
    public  Rigidbody rb;
    public float bounceSpeedMultiplier = 1.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //random start rotation
        transform.Rotate(Vector3.up * Random.Range(1,360));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);

        // check if it hits a boundary if so rebound
        // check if it collides with scoring zone if so destroy and add points the respawn

    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // detects collisions and turns ball around based on normal direction (angle in = angle out)
        Vector3 normal = collision.contacts[0].normal;
        Vector3 reflectedVelocity = Vector3.Reflect(rb.linearVelocity, normal);
        rb.linearVelocity = reflectedVelocity * bounceSpeedMultiplier;
        Debug.Log(rb.linearVelocity);
    }
}

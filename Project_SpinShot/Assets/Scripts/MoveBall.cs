using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class MoveBall : MonoBehaviour
{
    public LayerMask collisionMask;
    public float speed = 30f;
    public Rigidbody rb;
    public float bounceSpeedMultiplier = 1.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        BallMovement(Vector3.forward);
        // transform.Translate(speed * Time.deltaTime * Vector3.forward);
         // check if it hits a boundary if so rebound
                // check if it collides with scoring zone if so destroy and add points the respawn
      
        Debug.Log(rb.linearVelocity.ToString());
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed * .05f, collisionMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
            Debug.Log("should bounce back");
            
        }

    }
    private void Update()
    {
       
    }
    void BallMovement(Vector3 direction)
    {
        rb.AddForce(direction * speed);
        RandomRotate();
    rb.AddForce(speed * Time.deltaTime * Vector3.forward , ForceMode.Force);
    }
    void RandomRotate()
    {
         //random start rotation
        transform.Rotate(Vector3.up * Random.Range(1,360));
    }
       
}

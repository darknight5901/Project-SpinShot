using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;


public class MoveBall : MonoBehaviour
{
    public LayerMask collisionMask;
    public float initialSpeed = 20f;
    public float speed;
    public SphereCollider sc;
    public Rigidbody rb;
    [SerializeField] bool enableRandomizedStart = false;
    [SerializeField] bool canMove = false;
    [SerializeField] bool usingRay = false;
    [SerializeField] float speedIncrease = 1.01f;
    [SerializeField] int bounceCount;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();

    }
    void Start()
    {
        //Old Method Invoke(nameof(ResetBall), 2f);
        StartCoroutine(nameof(ResetBall), true);
        
    }
    private void Update()
    {
         
        //OLD WAY - switched to rb physics instead of translate
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //OldMethod Invoke(nameof(ResetBall), 1f);
            StartCoroutine(nameof(ResetBall), true);
        }
        
           

     
    }
    private void FixedUpdate()
    {
       
        speed =  initialSpeed + (speedIncrease * bounceCount);
        Ray ray = new(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, Time.deltaTime * speed, collisionMask) && usingRay)
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            ReflectBall(reflectDir, hit.transform.gameObject);
            Debug.DrawLine(ray.origin, hit.transform.position, Color.green);

        }
        Move();

        
            
        
       // = Vector3.ClampMagnitude(rb.linearVelocity,speed );
       // rb.AddForce (speed * , ForceMode.Acceleration);
         //speed = rb.linearVelocity.magnitude;
        // * initialSpeed * speedIncrease * bounceCount;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!usingRay)
        {
            Vector3 reflectDir = Vector3.Reflect(transform.forward, collision.contacts[0].normal);

            ReflectBall(reflectDir, collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Goal") && transform.position.x < 0)
        {
            
        }
        if (other.CompareTag("Goal") && transform.position.x > 0)
        {
            
        }
    }

    private void ReflectBall(Vector3 reflectDir , GameObject hitObject)
    {
        // adjusts y rotation to align with reflect rotation.
        float rot =   90 -(Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg);
        Vector3 position = hitObject.transform.position;

        float offset = transform.position.z - position.z;
        bounceCount ++;
        // use for  adding to  rot    Random.Range(-offset, offset)
            
            
        if (hitObject.CompareTag("Player") && (offset >= -.2 && offset <= .2)) 
        {
            float newOffset;
            newOffset = Random.Range(-10, 10);
            print(" Ball is too straight " + offset + newOffset + " Changed the reflect angle");
            transform.eulerAngles = new Vector3(0, rot + (( newOffset + offset) * 1.2f), 0);
        }
        else if (hitObject.CompareTag("Player"))
        {
            print(" Had to RANDOMIZE IT FOR FUN" + offset * 1.2f + " Changed the reflect angle");
            transform.eulerAngles = new Vector3(0, rot + (offset * 1.2f), 0);
        }
        else 
        {
            transform.eulerAngles = new Vector3(0, rot , 0);
        }
            print(offset);

        
    }
    private void Move()
    {
        if(canMove)
        { rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * transform.forward); }
       // rb.AddForce(transform.forward * speed, ForceMode.Impulse);
       
    }
    private void StartBall()
    {
       
        
        // transform.Rotate(startingDirection);
        //tutorial says | it doesn't work :(
        //  rb.linearVelocity = Vector3.forward * initialSpeed * speedIncrease ;
        Invoke(nameof(Move), 2f);
        speed = initialSpeed;
        canMove = true;
    }
    private void ResetBall(bool facingLeft)
    {
        canMove = false;
        speed = 0;
        rb.linearVelocity = Vector3.zero;
        
        bounceCount = 0;
        Invoke(nameof(StartBall), 1f);
        print("Ball was RESET");
        if (enableRandomizedStart)
        {
            RandomRotation(facingLeft);
            transform.position = new Vector3 (0, 10, 0);
        }
        else
        {
        transform.SetPositionAndRotation(new Vector3(0, 10, 0), new Quaternion(0, 0, 0, 0));
        }
    }
   void RandomRotation(bool left)
    {
        if (left)
        {
            int facingDirection = -1;
            Quaternion startingDirection = Quaternion.Euler(0, Random.Range((facingDirection * 45), (135 * facingDirection)), 0);
            transform.rotation = startingDirection;
        }
        if (!left)
        {
            int facingDirection = 1;
            Quaternion startingDirection = Quaternion.Euler(0, Random.Range((facingDirection * 45), (135 * facingDirection)), 0);
            transform.rotation = startingDirection;
        }
        print("is FacingLeft?" + left);
        
    }
}
  


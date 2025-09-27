using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public InputAction[] movePlayer;
    public float speed = 5f;
    public Vector3 movementInput;
    private Rigidbody rb;
    public int playerNumber;
    private float moveLimit = 10;
    private float bumpForce = 40;
    private void Awake()
    {
      
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        movePlayer[playerNumber].Enable();
    }

    // Update is called once per frame
    private void Update()
    {
           movementInput = movePlayer[playerNumber].ReadValue<Vector3>();
    }
    void FixedUpdate()
    {
        MoveCharacter(movementInput);
     
       

       // if (transform.position.z < -moveLimit)
       // {
            //transform.Translate(0, 0, -moveLimit);
            // bump it back
            //rb.AddForce(transform.right * bumpForce * 1);
       //     Debug.Log("push down");
        //}

       // if (transform.position.z > moveLimit)
           
       //  {
            //transform.Translate(0, 0, moveLimit);
        //    transform.position += new Vector3(0, 0, (moveLimit + 1));
            // bump it back
            // rb.AddForce(-transform.right * bumpForce * 1);
       //     Debug.Log("push up");
       // }
       
    }
    void MoveCharacter(Vector3 direction )
    {
        rb.AddForce(direction * speed ) ;
    }
}


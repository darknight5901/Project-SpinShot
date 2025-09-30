using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public InputAction[] movePlayer;
    public float speed = 5f;
    public Vector3 movementInput;
    private Rigidbody rb;
    public int playerNumber;
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
           movementInput = movePlayer[playerNumber].ReadValue<Vector2>();
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
    void MoveCharacter(Vector2 inputDirection )
    {
        Vector3 MoveDirection;
        MoveDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        print("player" + playerNumber + " " + MoveDirection);
        rb.AddForce(MoveDirection * speed, ForceMode.Force); ;
        
    }
}


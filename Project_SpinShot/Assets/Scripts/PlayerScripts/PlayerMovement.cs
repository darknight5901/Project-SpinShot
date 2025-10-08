using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;
    public InputAction[] movePlayer;

    public Vector3 movementInput;
    [SerializeField] private float speed = 5f;
    public int playerNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        movePlayer[playerNumber].Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAI)
        { AiControl(); }

        else
        { movementInput = movePlayer[playerNumber].ReadValue<Vector2>(); }
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
    void MoveCharacter(Vector2 inputDirection)
    {
        Vector3 MoveDirection;
        MoveDirection = new Vector3(inputDirection.x, 0, inputDirection.y);

        // rb.AddForce(MoveDirection * speed, ForceMode.Force);
        rb.linearVelocity = MoveDirection * speed;

    }
    private void AiControl()
    {
        if (ball.transform.position.z > transform.position.z + 0.5f)
        {
            // MoveCharacter(new Vector2 (0, 1));
            movementInput = new Vector2(0, 1);
        }
        else if (ball.transform.position.z < transform.position.z - 0.5f)
        {
            //  MoveCharacter(new Vector2(0, -1));
            movementInput = new Vector2(0, -1);
        }
        else
        {
            //  MoveCharacter(new Vector2(0, 0));
            movementInput = new Vector2(0, 0);
        }
    }
}


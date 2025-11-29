using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static GameSystemManager;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;
    public InputAction[] movePlayer;
    [SerializeField] float shotPower = 1.0f;
    [SerializeField] float shotPowerMulti = 10.0f;
    public Vector3 movementInput;
    [SerializeField] private float speed = 5f;
    public int playerNumber;
    public PlayerInformation playerInformation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
         rb = GetComponent<Rigidbody>();
        playerInformation.PlayerCharacter = gameObject;

       
    }
    void Start()
    {
      //   playerInformation = new PlayerInformation(gameObject, "Name", playerNumber, 0, Color.white, isAI);
       

       // movePlayer[playerNumber].Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAI)
        { AiControl(); }

        else
        { }
        ;
       // { movementInput = movePlayer[playerNumber].ReadValue<Vector2>(); }
    }
    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        shotPower = (movementInput.x + .5f) * shotPowerMulti;
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
        MoveDirection = new Vector3(0, 0, inputDirection.y);

        // rb.AddForce(MoveDirection * speed, ForceMode.Force);
        rb.linearVelocity = MoveDirection * speed;

    }
    void ShotPower(GameObject ball)
    {
     Rigidbody ballRB =  ball.GetComponent<Rigidbody>();
        ball.BroadcastMessage("SpeedUp", shotPower);
       // ballRB.AddForce(ball.transform.forward * shotPower , ForceMode.Force);
        
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && movementInput.x != 0)
        ShotPower(collision.gameObject);
    }
    private void AiControl()
      
    {
        float offset = Random.Range(-.5f, 1f);
        if (ball.transform.position.z > transform.position.z + offset )
        {
            // MoveCharacter(new Vector2 (0, 1));
            movementInput = new Vector2( Random.Range(-1,1), 1);
        }
        else if (ball.transform.position.z < transform.position.z - offset)
        {
            //  MoveCharacter(new Vector2(0, -1));
            movementInput = new Vector2(Random.Range(-1, 1), -1);
        }
        else
        {
            //  MoveCharacter(new Vector2(0, 0));
            movementInput = new Vector2(0, 0);
        }
    }
    [SerializeField] bool printCallLoop;
    public void StartLoop()
    {
        StartCoroutine(PrintDebugLooper("ShotPower", (ball.transform.forward * (shotPower + shotPowerMulti * movementInput.x) + "is the shot power"), 3));
        print(" Print Loop Started");
    }
    IEnumerator PrintDebugLooper(string callName, string callContext, float loopTime)
    {
        
        int loopNumber = 0;
        printCallLoop = true;
        WaitForSeconds waitInstruction = new (loopTime);
        while (printCallLoop)
        {
            loopNumber++;
            print(callName + " (" + loopNumber + ") " + callContext);
            yield return waitInstruction;
        }
        print("debugger is stopped");
    }
    // Call this method to stop the printCall loop
    public void StopLoop()
    {
        printCallLoop = false;
    }
}



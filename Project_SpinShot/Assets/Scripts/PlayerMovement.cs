using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public InputAction[] movePlayer;
    public float speed = 5f;
    public Vector2 movementInput;
    private Rigidbody2D rb;
    public int playerNumber;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        movePlayer[playerNumber].Enable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        movementInput = movePlayer[playerNumber].ReadValue<Vector2>();
       transform.Translate(movementInput.y * speed * Time.deltaTime * Vector3.right);
        Debug.Log(movementInput.y);
    }
}

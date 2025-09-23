using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public InputAction movePlayer;
    public float speed = 5f;
    private Vector2 movementInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
        movePlayer.Enable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        movementInput = movePlayer.ReadValue<Vector2>();
       transform.Translate(movementInput.y * speed * Time.deltaTime * Vector3.right);
    }
}

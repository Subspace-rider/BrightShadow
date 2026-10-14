using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    public Rigidbody2D playerRB;
    public Vector2 moveInput;
    //public Vector2 jumpInput;
    public bool grounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        playerRB.linearVelocity = new Vector2(moveInput.x * moveSpeed, playerRB.linearVelocity.y); 
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if(grounded == true && value.isPressed)
        {
            playerRB.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            
        }
         
    }
   
    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
         if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
    void Update()
    {
        
    }
}

using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class movement : MonoBehaviour
{
    //move variables
    public float MovementSpeed = 5f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    // Jump variables
    public bool canJump = true;
    public bool IsGrounded;
    public float jumpValue = 0.0f;
    public LayerMask groundMask;
    
    
    

   public void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
    }

    
    public void Update()
    {
        // movement for X axis
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.A)) moveX = 1;
       
        if (Input.GetKey(KeyCode.D)) moveX = -1;
        
        moveDirection = new Vector2(moveX,moveY).normalized;

        // Jumping
        if(Input.GetKey("space") && IsGrounded && canJump)
        {
            jumpValue += 0.1f;
        }
        
         
        if(jumpValue >= 20f && IsGrounded)
        {
            float tempX =  0;
            float tempY = jumpValue;
            rb.linearVelocity = new Vector2(tempX,tempY);
            Invoke("ResetJump", 0.2f);
        }

        if (Input.GetKeyUp("space"))
        {
            canJump = true;
        }

        IsGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y - 0.5f),
         new Vector2(0.9f,0.4f),0f,groundMask);
    
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }




    void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * MovementSpeed;

    }
}

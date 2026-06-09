using UnityEngine;

public class Moving : MonoBehaviour
{
    // variables 
    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;
    public bool canJump = true;
    public float JumpValue = 0.0f;
    public Animator animator;
    int RandInt;

    public string test;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
       


        // getting input to move the palyer
        moveInput = Input.GetAxisRaw("Horizontal");
        moveInput *= -1;
        rb.linearVelocity = new Vector2(moveInput * walkSpeed, rb.linearVelocity.y);

        
        // creating way to check if player is touching the ground
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y - 0.5f), new Vector2(0.9f,0.4f),0f,groundMask);

        // getting input to make player jump
        if(Input.GetKey("space") && isGrounded && canJump)
        {
            JumpValue += 0.1f;
            
        }


        if (Input.GetKeyUp("space"))
        {
            RandInt = UnityEngine.Random.Range(1, 5);
            Debug.Log(RandInt);

            if (RandInt == 3)
            {
                animator.SetTrigger("kickflip");
                rb.linearVelocity = new Vector2(moveInput * walkSpeed, JumpValue);
                JumpValue = 0.0f;
            }
            
            
           else if (isGrounded)
            {
                animator.SetTrigger("IsOlling");
                rb.linearVelocity = new Vector2(moveInput * walkSpeed, JumpValue);
                JumpValue = 0.0f;


            }
            canJump = true;
        }
        // checking to see if player is grounded so they can jump
        else if (JumpValue >= 7f && isGrounded)
        {
            animator.SetTrigger("IsOlling");
            float tempX = moveInput * walkSpeed;
            float tempY = JumpValue;
            rb.linearVelocity = new Vector2(tempX,tempY);
            Invoke("ResetJump",0.2f);
        }
        // jumping
        
        
    }
    void ResetJump()
    {
        canJump = false;
        JumpValue = 0;

    }
}

using NUnit.Framework;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool canJump = true;
    public bool IsGrounded;
    public float jumpValue = 0.0f;
    public LayerMask groundMask;
    void Start()
    {
        
    }

    
    void Update()
    {

        if(Input.GetKey("space") && IsGrounded && canJump)
        {
            jumpValue += 0.1f;
        }
        
        
        if(jumpValue >= 20f && IsGrounded)
        {
            
        }




        IsGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x,gameObject.transform.position.y - 0.5f),
         new Vector2(0.9f,0.4f),0f,groundMask);
    }

    
}

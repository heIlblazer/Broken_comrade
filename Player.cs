using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int energyCapacity = 10000;
    public Rigidbody2D rb;
    public bool leg;
    public bool facingRight = true;
    public float moveInput;
    public float speed;
    public bool hitted = false;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float jumpForce;
    //private int extraJumps;
    public int extraJumpValue;

    void Start()
    {
        leg=  false;
    // extraJumps = extraJumpValue;
    rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }


        //Energy spending
        if (Input.GetKey("d"))
        {
            energyCapacity--;
        }
        else if (Input.GetKey("a"))
        {
            energyCapacity--;
        }
        else if (Input.GetKey("space"))
        {
            energyCapacity -= 10;
        }



        //Flipping
        if (facingRight == true && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == false && moveInput < 0)
        {
            Flip();
        }
        }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "battery")
        {
            Debug.Log("Есть контакт");
            energyCapacity += 10;
            Destroy(other.gameObject);
            Debug.Log("delete");
        }
        if (other.tag == "Leg")
        {
            leg = true;
        }
        if (other.tag == "lightn")
        {
            Debug.Log("push start" + energyCapacity);
            hitted = true;
            //animset Hitted
            energyCapacity= energyCapacity/2;
            Debug.Log("push end" + energyCapacity);
        }
    }
    void Update()
    {
       

        if ((Input.GetKeyDown(KeyCode.Space)) && leg == true)
        {

            rb.velocity = Vector2.up * jumpForce;
            //extraJumps--;

        }
      //  else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
       // {
        //    rb.velocity = Vector2.up * jumpForce;
        //}
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}


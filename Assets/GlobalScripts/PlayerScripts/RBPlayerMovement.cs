using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBPlayerMovement : MonoBehaviour
{
    //Components
    [HideInInspector]
    public Rigidbody rb;
    private CapsuleCollider collider;
    public LayerMask whatIsGround;
    public Transform playerMesh;
    //Input
    private float xInput;
    private float zInput;
    //Movement
    public float playerSpeed;
    public float maxVelocity;
    //Jump
    public float jumpForce;
    private float jumpCount = 0f;
    private bool onGround;
    private bool shouldCheckForJump;
    //Slide
    public float slideCounterMovement;
    public float slideBoost;
    [HideInInspector]
    public bool isSliding;
    //Counter Movement
    public float counterMovement;
    //Velocity in Local Axes
    private float xLocalVel;
    private float zLocalVel;
    private Vector3 localVel;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        shouldCheckForJump = true;
        jumpCount = 1;
    }

    void Update()
    {
        LocalAxesVel();
        
        //Extra Variables

        //Input   
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        //Extra Gravity
        rb.AddForce(Vector3.up*-2f);

        //Jump
        if(Physics.Raycast(transform.position,-transform.up,out RaycastHit groundDetector,(collider.height/2f)+collider.radius - 0.45f,whatIsGround))
        {
            onGround = true;
            Debug.Log("Working");
        }
        if(Input.GetKeyDown(KeyCode.Space) && onGround && jumpCount > 0 && shouldCheckForJump)
        {
            rb.AddForce(transform.up*jumpForce,ForceMode.Impulse);
            jumpCount--;
            onGround = false;
            shouldCheckForJump = false;
            Invoke("CheckForCanJump",1f);

        }
        
        //Sliding
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            collider.height /= 5f;
            playerMesh.localScale /= 5f;
            rb.AddForce(rb.velocity.normalized*slideBoost*zInput);
            isSliding = true;
            maxVelocity +=20f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            collider.height *= 5f;
            playerMesh.localScale *= 5f;
            isSliding = false;
            maxVelocity -= 20;
        }
        if(isSliding)
        {
            rb.AddForce(rb.velocity.normalized*-slideCounterMovement*Time.deltaTime);
            rb.AddForce(Vector3.down*5f);
            xInput =0; zInput =0;
            
        }
        
        //Limit Movement by removing additional Force
        if(xInput > 0 && xLocalVel > maxVelocity)
        {
            xInput = 0;
        }
        if(xInput < 0 && xLocalVel < -maxVelocity)
        {
            xInput = 0;
        }
        if(zInput > 0 && zLocalVel > maxVelocity)
        {
            zInput = 0;
        }
        if(zInput < 0 && xLocalVel < -maxVelocity)
        {
            zInput = 0;
        }
        //Limiting Velocity
        if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > maxVelocity && !isSliding)
         {
            float fallspeed = rb.velocity.y;
            Vector3 n = rb.velocity.normalized * maxVelocity;
            rb.velocity = new Vector3(n.x, fallspeed, n.z);
        }

        //Movement
        Vector3 xForce = transform.right*xInput*playerSpeed*Time.deltaTime;
        Vector3 zForce = transform.forward*zInput*playerSpeed*Time.deltaTime;
        rb.AddForce(xForce+zForce,ForceMode.VelocityChange);
        
        //Counter Movement
        if(!isSliding)
        {
            if(Mathf.Abs(xLocalVel) > 0.5f && Mathf.Abs(xInput) < 0.1f || xLocalVel > 0.5f && (xInput) < -0.1f || (xLocalVel) < -0.5f && xInput > 0.1f )
            {
                rb.AddForce(transform.right * -xLocalVel * playerSpeed * counterMovement * Time.deltaTime ,ForceMode.Impulse);
            }
            if(Mathf.Abs(zLocalVel) > 0.5 && Mathf.Abs(zInput) < 0.1f || (zLocalVel) > 0.5f && zInput < -0.1f || (zLocalVel) < -0.5f && zInput > 0.1f)
            {
                rb.AddForce(transform.forward * -zLocalVel * playerSpeed * counterMovement * Time.deltaTime , ForceMode.Impulse);
            }
        }
    }

    void LocalAxesVel()
    {
        localVel = transform.InverseTransformDirection(rb.velocity);
        xLocalVel = localVel.x;
        zLocalVel = localVel.z;
    }
    void CheckForCanJump()
    {
        shouldCheckForJump = true;
        jumpCount = 1;
    }
}

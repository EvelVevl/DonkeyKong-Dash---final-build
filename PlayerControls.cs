using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpHeight = 2.4f;
    public float gravity = -15f;
    public Transform ground;
    public float distanceToGround = 0.4f;
    public LayerMask groundMask;
    private CharacterInput controls;
    private CharacterController controller;
    private int jumpAllowance = 1;
    private Vector2 move;
    private Vector3 velocity;
    public AudioSource Jumping;

    private void Awake()
    {
        controls = new CharacterInput();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Grav();
        Jump();

        if (transform.position.x > 6)
        {
            transform.position = new Vector3(6, transform.position.y, transform.position.z);
        }

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }


        // HERE IS WHERE I WILL BE ADDING IN MY ON COLLISION STATEMENTS FOR THINGS 

     void OnTriggerEnter (Collider other)
    {
        Debug.Log("collided");

        if (other.CompareTag("superSpeed"))
        {
            superSpeed();  
            Debug.Log("SuperSpeed");
        }
        else if (other.CompareTag("doubleJump"))
        {
            doubleJump();  
            Debug.Log("doubleJump");
        }
    }

        // HERE IS WHERE MY STUFF ENDS :)

    public void changeSpeed(int newSpeed){
        moveSpeed = newSpeed;
    }

    private void PlayerMovement()
    {
        move = controls.Player.Movement.ReadValue<Vector2>();
        Vector3 forwardMovement = transform.forward;
        var movement = forwardMovement + move.x * transform.right;
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(ground.position, distanceToGround, groundMask);
    }

    private void Grav()
    {
        if (IsGrounded() && velocity.y <= 0)
        {
            velocity.y = -2f;
            jumpAllowance = 1;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (IsGrounded() && controls.Player.Jump.triggered && jumpAllowance > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Jumping.Play();
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // STUFF THAT I ADDED IS FROM HERE WITH FUNCTIONS


    
    private void superSpeed()
    {
        moveSpeed = moveSpeed * 2;
        Invoke("dropPower", 5f);
    }

    private void doubleJump()
    {
        jumpHeight = jumpHeight * 2;
        Invoke("dropPower", 5f);
    }

    private void dropPower(){
        moveSpeed = 6f;
        jumpHeight = 2.4f;
        Debug.Log("player dropped");
    }
}
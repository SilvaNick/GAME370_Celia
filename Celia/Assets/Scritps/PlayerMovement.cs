using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //gets the controller attached to the player object
    public CharacterController controller;

    // variables for movement, jump and gravity
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    //variables used to check if the player is grounded
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField]bool isGrounded;

    //Vector that is used to move the player
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //checks to see if the player is making contact with the ground layer
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //adds the feeling of friction to the player so they dont slide everywhere
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //used to determine if the player is moving right (1) or left (-1)
        float x = Input.GetAxis("Horizontal");
        
        // creates a unit vector using either 1 or -1 for right or left. 
        Vector3 move = transform.right * x; 

        //moves the characterController in the move direction at the speed variable and uses Time.deltaTime
        controller.Move(move * speed * Time.deltaTime);

        //Checks to see if the player presses the jump input and if the player is grounded.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //adds a jump force to the velocity.y making the player jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // if the player is in the air this adds the gravity to lower them over time
        velocity.y += gravity * Time.deltaTime;

        // this moves the controller
        controller.Move(velocity * Time.deltaTime);
    }



}

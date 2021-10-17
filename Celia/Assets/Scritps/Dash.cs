using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    // THIS IS A WORK IN PROGRESS AND IS NOT WORKING CORRECTLY

    public CharacterController controller;
    public Rigidbody rBody;

    public const float maxDashTime = 1.0f;
    public float dashDistance = 10;
    public float dashStoppingSpeed = 0.1f;
    [SerializeField] private float currenDashTime = maxDashTime;
    [SerializeField] private float dashSpeed = 6;
    [SerializeField] public KeyCode dash;
    [SerializeField] bool canDash;

    public Vector3 moveDirection;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded)
        {
            canDash = true;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * y;

        if (Input.GetKey(dash) && canDash)
        {
            currenDashTime = 0;
            canDash = false;
        }

        if(currenDashTime < maxDashTime)
        {
            moveDirection = move * dashDistance;
            currenDashTime += dashStoppingSpeed;
        } else
        {
           moveDirection = Vector3.zero;
        }

        controller.Move(moveDirection * Time.deltaTime * dashSpeed);
    }

}

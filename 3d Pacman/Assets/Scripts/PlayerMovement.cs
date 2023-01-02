using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    float vertical;

    Vector3 move;

    bool isGrounded;

    [SerializeField]
    float jumpHeight = 3f;

    [SerializeField]
    CharacterController motor;

    [SerializeField]
    Transform feet;

    [Header("Dynamic FOV")]

    [SerializeField]
    Camera cam;

    [SerializeField]
    GameObject runLines;

    float defaultFOV = 60f;

    [SerializeField]
    float sprintFOV = 70f;

    [SerializeField]
    float groundDist;

    [SerializeField]
    LayerMask whatIsGround;

    [SerializeField]
    float gravity = -9.81f;

    [SerializeField]
    float walkSpeed = 15f;

    [SerializeField]
    float runSpeed = 20f;

    float speed = 15f;

    bool isMoving;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(feet.position, groundDist, whatIsGround);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(vertical > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        move = transform.right * horizontal + transform.forward * vertical;

        ControlSpeed();

        motor.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;

        

        motor.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    void ControlSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, sprintFOV, 10f * Time.deltaTime);

            if (isMoving)
            {
                runLines.SetActive(true);
            }
            else
            {
                runLines.SetActive(false);
            }
        }
        else
        {
            speed = walkSpeed;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultFOV, 10f * Time.deltaTime);
            runLines.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    float x;
    float z;
    Vector3 move;
    //Gravedad
    Vector3 velocity;
    public float gravity = -9.8f;
    public Transform groundCheck;
    float radius = 0.4f;
    public LayerMask mask;
    bool isGrounded = false;
    public float jumpForce = 1f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = gravity;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform _camera;

    public float moveSpeed = 4f;
    public float jumpForce = 6f;

    public LayerMask Ground;

    public bool isGrounded;

    void Update()
    {
        //grounding
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 1f, Ground);


        //facing direction
        Debug.DrawLine(_camera.position, transform.forward * 2.5f);

        //moving
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //setting movement
        Vector3 move = transform.right * x + transform.forward * y;

        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }
}


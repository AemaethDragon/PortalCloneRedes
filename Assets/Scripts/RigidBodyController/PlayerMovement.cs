using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController playerController;
    public Rigidbody rb;
    public Transform _camera;
    public LayerMask Ground;
    public bool isGrounded;

    private float _jumpForce = 7f;
    private float _moveSpeed = 4f;

    void Update()
    {
       if (!playerController.Playable) return;
        
        //grounding
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 1f, Ground);
        
        //facing direction
        Debug.DrawLine(_camera.position, transform.forward * 2.5f);
        
        //moving
        float x = Input.GetAxisRaw("Horizontal") *  _moveSpeed;
        float y = Input.GetAxisRaw("Vertical") *  _moveSpeed;
        
        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
            rb.velocity = new Vector3(rb.velocity.x, _jumpForce, rb.velocity.z);

        //setting movement
        Vector3 move = transform.right * x + transform.forward * y;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }
}


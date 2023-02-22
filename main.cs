using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 0f;
    [SerializeField] public float jumpSpeed = 0f;
    
    private Vector3 movement;
    private Vector3 height;
    private bool isJumping = false;
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Move(float horizontal, float vertical)
    {
        movement.Set(horizontal,0,vertical);
        movement = movement.normalized * playerSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        rb.AddForce(new Vector3(movement.x,jumpSpeed,movement.z));
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"), v = Input.GetAxisRaw("Vertical");
        isJumping = Input.GetKeyDown("space");
        Move(h,v);
        if (isJumping)
        {
            Jump();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float maxSpeed = 6f;
    public float dashForce = 5f;
    public float dashDuration = 1;
    public float dashCooldown = 2f;
    
    private RaycastHit2D hit;
    private bool dashing = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector2 movement_vector = new Vector2(moveH * maxSpeed, moveV * maxSpeed);
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashing)
        {
            dashing = true;
            //dash
            dashing = false;
        }
    }
}


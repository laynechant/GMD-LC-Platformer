using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    private bool _facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (_facingRight && rb.velocity.x < -0.1)
        {
            Filp();
        }
        else if (!_facingRight && rb.velocity.x > 0.1)
        {
            Filp();
        }
        animator.SetFloat("MoveSpeedX", Mathf.Abs(rb.velocity.x)/ playerMovement.XSpeed);
        animator.SetBool("Grounded", playerMovement.IsGrounded);
    }

    private void Filp()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}

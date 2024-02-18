using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed = 10;
    public float XSpeed => xSpeed;
    [SerializeField] private float jumpForce = 800f;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr; 
    private Rigidbody2D _rb;

    private float _xMoveInput;

    private bool _shouldJump;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;

    private bool canDash = true; 
    bool isDashing;
    private float dashingPower = 4f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f; 

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (isDashing)
        {
            return; 
        }
        
        _xMoveInput = Input.GetAxis("Horizontal") * xSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shouldJump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return; 
        }

        Collider2D col = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
             _isGrounded = col != null;  
            _rb.velocity = new Vector2(_xMoveInput, _rb.velocity.y);
            if (_shouldJump )
            {
                 if (_isGrounded)
                 {
                    _rb.AddForce(Vector2.up * jumpForce);
                 }
                _shouldJump = false; 
            }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _isGrounded ? Color.green: Color.red;
        Gizmos.DrawWireSphere(transform.position,groundCheckRadius);  
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform, true);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null, true);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(_xMoveInput * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        _rb.gravityScale = originalGravity;
        isDashing = false; 
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player Components")]

    [SerializeField] GameObject player;
    [SerializeField] private Rigidbody2D rb;
    public int playerHealth = 3;

    [Header("Movement Variables")]

    private float speed = 5f;
    private float jumpForce = 10f;
    private float horizontal;
    private bool isFacingRight = true;
    private bool doubleJump = true;

    [Header("Ground Check")]

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    [Header("Dash Variables")]

    [SerializeField] private float dashVelocity = 5f;
    [SerializeField] private float dashingTime = 0.5f;
    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash = true;

    // unoptimized as FUCK will make code better at some point LOL
    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
        // For jump / x2 jump functionlaity
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        if (isGRounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGRounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                doubleJump = !doubleJump;
            }
            /* (isGRounded() && !Input.GetButton("Jump"))
            {
                doubleJump = false;
            }*/
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // For dashing functionality
        if (Input.GetButtonDown("Dash") && canDash)
        {
            isDashing = true;
            canDash = false;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0f);
            }
            StartCoroutine(StopDashing());
        }
        if (isDashing)
        {
            rb.velocity = dashingDir.normalized * dashVelocity;
            return;
        }

        if (isGRounded())
        {
            canDash = true;
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private bool isGRounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.6f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }
}
    

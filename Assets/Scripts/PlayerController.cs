using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CapsuleCollider2D standingCollider;

    private Rigidbody2D rb;
    private float moveInput;
    private bool canJump = false;
    private bool isFacingRight = true;

    public bool goesRight => rb.velocity.x >= 0;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);

        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            canJump = true;
        }

        Flip();

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        } else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            StopCrouch();
        }



    }

    private void FixedUpdate()
    {

        Move();

        if (canJump)
        {
            playerAnimator.SetTrigger("Jump");
            Jump(jumpForce);
            canJump = false;
        }
        
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        playerAnimator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

    }

    private void Jump(float jumpForce)
    {
        rb.AddForce(new Vector2(0f, jumpForce));
    }

    private void Flip()
    {
        if(goesRight != isFacingRight)
        {
            var lc = transform.localScale;
            isFacingRight = !isFacingRight;
            lc.x *= -1;
            transform.localScale = lc;
        }

    }

    private void Crouch()
    {
        playerAnimator.SetTrigger("Crouch");
        speed /= 2;
        jumpForce /= 2;
        standingCollider.enabled = false;
    }

    private void StopCrouch()
    {
        playerAnimator.SetTrigger("StopCrouch");
        speed *= 2;
        jumpForce *= 2;
        standingCollider.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
    }
}

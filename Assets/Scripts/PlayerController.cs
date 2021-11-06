using System;
using System.Collections;
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
    [SerializeField] private GameObject ceilingCheck;
    [SerializeField] private float ceilingCheckRadius;
    [SerializeField] private AudioManager audioManager;

    private Rigidbody2D rb;
    private float moveInput;
    private bool canJump = false;
    private bool isFacingRight = true;
    private bool isCrouched = false;
    private bool stepEnded = true;
    private bool isGrounded = true;

    public bool goesRight => Input.GetAxisRaw("Horizontal") == 1;
    public bool goesLeft => Input.GetAxisRaw("Horizontal") == -1;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Flips sprite when needed
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            Flip();
        }

        //Setup conditions for jumping
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);

        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            canJump = true;
        }

        //Crouches when needed
        CrouchController();

    }

    private void FixedUpdate()
    {
        Move();

        if (canJump)
        {
            Jump(jumpForce);
            canJump = false;
        }
        
    }
    private IEnumerator StepSound() {
        audioManager.Play("step");
        yield return new WaitForSeconds(0.5f);
        stepEnded = true;
        
    }
    private void Move()
    {
        if (moveInput != 0 && stepEnded && isGrounded) {
            StartCoroutine(StepSound());
            stepEnded = false;
            
        }
        rb.velocity = new Vector2(moveInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        playerAnimator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

    }

    private void Jump(float jumpForce)
    {
        playerAnimator.SetTrigger("Jump");
        rb.AddForce(new Vector2(0f, jumpForce));
    }

    private void Flip()
    {
        if(goesLeft && isFacingRight)
        {
            var lc = transform.localScale;
            lc.x *= -1;
            transform.localScale = lc;
            isFacingRight = false;
        } else if(goesRight && !isFacingRight)
        {
            var lc = transform.localScale;
            lc.x *= -1;
            transform.localScale = lc;
            isFacingRight = true;
        }
    }

    //Crouches and uncrouches when needed
    private void CrouchController()
    {
        bool isUnderCeiling = Physics2D.OverlapCircle(ceilingCheck.transform.position, ceilingCheckRadius, groundLayer);

        //If crouch key pressed and not under ceiling -> crouch
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isUnderCeiling)
        {
            Crouch();
            isCrouched = true;
        }
        //If crouched and crouch key pressed and not under ceiling -> stop crouching
        else if (isCrouched && !Input.GetKey(KeyCode.LeftControl) && !isUnderCeiling)
        {
            StopCrouch();
            isCrouched = false;
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
        Gizmos.DrawWireSphere(ceilingCheck.transform.position, ceilingCheckRadius);
    }
}

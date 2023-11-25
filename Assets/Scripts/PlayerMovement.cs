using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float goundedRange = 0.2f;
    [SerializeField] private Transform wallChecker;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float wallRange = 0.2f;
    [SerializeField] private Transform attackChecker;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackRange = 0.1f;
    [SerializeField] private bool isFacingRight = true;

    [Space(20)]
    [SerializeField] private bool isGrounding;
    [SerializeField] private float horizontal;
    [SerializeField] public float speed = 5f;
    [SerializeField] private float jumpingPower = 16.0f;
    [SerializeField] private Vector2 position;

    [Space(20)]
    [SerializeField] private bool isWallSliding;
    [SerializeField] private float wallSlidingSpeed = 2.0f; // must more than 2.0f

    [Space(20)]
    [SerializeField] private bool isWallJumping;
    [SerializeField] private float wallJumpingDirection;
    [SerializeField] private float wallJumpingTime = 0.2f;
    [SerializeField] private float wallJumpingCounter;
    [SerializeField] private float wallJumpingDuration = 0.4f;
    [SerializeField] private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [Space(20)]
    [SerializeField] private GameObject Event;
    [SerializeField] private bool isInAttackRange;
    [SerializeField] private Collider2D[] hitEnemies;
    [SerializeField] private bool canMoveVertically = true;
    public void DisableVerticalMovement()
    {
        canMoveVertically = false;
    }

    public void EnableVerticalMovement()
    {
        canMoveVertically = true;
    }

    void Start()
    {
        isFacingRight = true;
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        position = new Vector2(this.transform.position.x, this.transform.position.y);

        // Left and right movement
        if (isWallJumping == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            //Debug.Log(horizontal);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        // Jump
        if (canMoveVertically == true)
        {
            speed = 5f;
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);// 处理垂直移动逻辑
                                                                       //animator.SetTrigger("isJump");
                                                                       //animator.SetBool("isGrounded", false);
            }

        }
        if (canMoveVertically == false)
        {
            speed = 0;
            if(Input.GetButtonDown("Jump") && IsGrounded())
        
            {
            rb.velocity = new Vector2(rb.velocity.x, 0);// 处理垂直移动逻辑

            }
        }
        

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        isGrounding = IsGrounded();
        WallSlide();
        WallJump();
        isInAttackRange = InAttackRange();



        if (!isWallJumping)
        {
            Flip();
        }

        if (isGrounding == true)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        if (isWallSliding == true)
        {
            animator.SetBool("isWallSlide", true);
        }
        else
        {
            animator.SetBool("isWallSlide", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack1(); 
        }
    }

    private void Attack1()
    {
        animator.SetTrigger("isAttack01");
        SoundManager.Instance.PlaySE(SESoundData.SE.Attack);

        if (Event.GetComponent<Timing>().onBeat == true)
        {
            hitEnemies = Physics2D.OverlapCircleAll(attackChecker.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyController>().TakeDamage();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackChecker == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackChecker.position, attackRange);
    }

    private bool InAttackRange()
    {
        return Physics2D.OverlapCircle(attackChecker.position, attackRange, enemyLayer);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, goundedRange, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallChecker.position, wallRange, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            //rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1.0f;
            transform.localScale = localScale;
        }
    }
}
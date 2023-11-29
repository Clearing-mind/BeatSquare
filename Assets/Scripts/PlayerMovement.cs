using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 initialPosition;

    [Space(20)]
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
    [SerializeField] public float speed;
    [SerializeField] private float jumpingPower;

    [Space(20)]
    [SerializeField] private bool isWallSliding;
    [SerializeField] private float wallSlidingSpeed = 3.0f; // must more than 2.0f

    [Space(20)]
    [SerializeField] private bool isWallJumping;
    [SerializeField] private float wallJumpingDirection;
    [SerializeField] private float wallJumpingTime = 0.2f;
    [SerializeField] private float wallJumpingCounter;
    [SerializeField] private float wallJumpingDuration = 0.4f;
    [SerializeField] private Vector2 wallJumpingPower = new Vector2(8f, 16f);

    [Space(20)]
    [SerializeField] private GameObject Event;
    [SerializeField] private GameObject VFX;
    [SerializeField] private bool isInAttackRange;
    [SerializeField] private Collider2D[] hitEnemies;

    // liye
    [SerializeField] private bool canMoveVertically;
    private float originalSpeed;

    // liye
    public void DisableVerticalMovement()
    {
        canMoveVertically = false;
    }

    // liye
    public void EnableVerticalMovement()
    {
        canMoveVertically = true;
    }

    void Start()
    {
        isFacingRight = true;
        animator = this.GetComponent<Animator>();
        originalSpeed = speed;
        initialPosition = this.transform.position;
    }

    void Update()
    {

        // Left and right movement
        if (isWallJumping == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            //Debug.Log(horizontal);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        // liye
        // Jump
        if (canMoveVertically == true)
        {
            speed = originalSpeed * currentSpeedMultiplier;
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                if (Event.GetComponent<Timing>().onBeat == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);// 处理垂直移动逻辑
                    SoundManager.Instance.PlaySE(SESoundData.SE.Jump_Full);
                    VFX.gameObject.SetActive(true);
                    //animator.SetTrigger("isJump");
                    //animator.SetBool("isGrounded", false);
                }
                //else
                //{
                //    rb.velocity = new Vector2(rb.velocity.x, jumpingPower / 2.0f);
                //    SoundManager.Instance.PlaySE(SESoundData.SE.Jump_Half);
                //}
            }
        }

        // liye
        if (canMoveVertically == false)
        {
            speed = 0.0f;
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);// 处理垂直移动逻辑
            }
        }

        //if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}


        isGrounding = IsGrounded();
        WallSlide();
        WallJump();
        isInAttackRange = InAttackRange();

        if (this.transform.position.y <= -20.0f)
        {
            Respawn();
        }

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

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack3();
        }

    }
    // liye
    // 在类的顶部定义一个变量来存储当前的速度倍率
    private float currentSpeedMultiplier = 1.0f;
    private bool hasAppliedMultiplier = false;
    //这里设置了加速物品的放大倍率，链接到了物体脚本上，方便今后直接调整物体脚本而不动用角色脚本
    public void SetSpeedMultiplier(float multiplier, float delay)
    {
        // 只在初次设置时进行乘法操作
        if (!hasAppliedMultiplier)
        {
            // 在这里修改速度
            if (horizontal > 0f)
            {
                speed = speed * multiplier;
                // 记录当前速度倍率
                currentSpeedMultiplier = multiplier;
                Invoke(nameof(ResetSpeed), delay);
                hasAppliedMultiplier = true; // 将标志设置为 true，表示已经应用了速度倍率
            }
        }
    }

    //liye
    void ResetSpeed()
    {
        // 还原速度为初始值或者之前的倍率
        speed = originalSpeed * currentSpeedMultiplier;
        hasAppliedMultiplier = false; // 将标志重置为 false，以便在下一次调用 SetSpeedMultiplier 时可以再次应用倍率
    }
    //liye

    private void Attack1()
    {
        if (Event.GetComponent<Timing>().onBeat == true)
        {
            animator.SetTrigger("isAttack01");
            SoundManager.Instance.PlaySE(SESoundData.SE.Attack);
            VFX.gameObject.SetActive(true);

            hitEnemies = Physics2D.OverlapCircleAll(attackChecker.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyController>().TakenDamage();
            }
        }
    }

    private void Attack2()
    {
        if (Event.GetComponent<Timing>().onBeat == true)
        {
            animator.SetTrigger("isAttack02");
            SoundManager.Instance.PlaySE(SESoundData.SE.Attack);
            VFX.gameObject.SetActive(true);

            hitEnemies = Physics2D.OverlapCircleAll(attackChecker.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyController>().TakenDamage();
            }
        }
    }

    private void Attack3()
    {
        if (Event.GetComponent<Timing>().onBeat == true)
        {
            animator.SetTrigger("isAttack03");
            SoundManager.Instance.PlaySE(SESoundData.SE.Attack);
            VFX.gameObject.SetActive(true);

            hitEnemies = Physics2D.OverlapCircleAll(attackChecker.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyController>().TakenDamage();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            this.GetComponent<PlayerMovement>().Respawn();
        }
    }

    public void Respawn()
    {
        this.transform.position = initialPosition;
    }

}
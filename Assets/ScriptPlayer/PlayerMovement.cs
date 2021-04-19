using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static public int currentcheckpoint = 0;
    public CharacterController2D controller;
    public CharacterSwitch characterswitch;
    float horizontalmove = 0.0f;
    public float runspeed = 3.0f;
    public HealthBar healthBar;
    public PlayerHp playerhp;
    public bool isplayer2 = false;
    public bool knockbackright = false;

    public float iframetime = 2.5f;

    int framecountdown = 30;

    [HideInInspector] public bool isFacingright = true;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool isGround = true;
    [HideInInspector] public bool isFalling = false;
    [HideInInspector] public bool isDamaged = false;
    [HideInInspector] public bool isDamagedanim = false;
    [HideInInspector] public bool ChargeAttacking = false;

    void Start()
    {

    }

    void Update()
    {
        if (!isGround)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            if (rb.velocity.y < 0)
            {
                isFalling = true;
            }
            else
            {
                isFalling = false;
            }
        }
        /*if (iframe > 0)
        {
            isDamaged = true;
        }
        if (iframe == 0)
        {
            isDamaged = false;
        }*/
        if (characterswitch.IsControling == true)
        {
            if (isplayer2 == false)
            {
                horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
                if (Input.GetButtonDown("Jump") && !isAttacking)
                {
                    jump = true;
                }
            }
            else
            {
                horizontalmove = Input.GetAxisRaw("Horizontal2") * runspeed;
                if (Input.GetButtonDown("Jump2"))
                {
                    jump = true;
                }
            }
        }
        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.deltaTime,false,jump);
        jump = false;
        if (horizontalmove > 0)
        {
            isMoving = true;
            isFacingright = true;
        }
        else if (horizontalmove < 0)
        {
            isMoving = true;
            isFacingright = false;
        }
        else
        {
            isMoving = false;
        }
        if (isAttacking == true && framecountdown > 0)
        {
            framecountdown -= 1;
            if (framecountdown == 0)
            {
                framecountdown = 30;
                isAttacking = false;
            }
        }
        if (isAttacking == false)
        {
            framecountdown = 30;
        }
        /*if (iframe > 0)
        {
            iframe -= 1;
        }*/
    }
    public void TakeDamage(float damage)
    {
        if (!isDamaged)
        {
            playerhp.currentHealth -= damage;
            healthBar.SetHealth(playerhp.currentHealth);
            StartCoroutine(IframeCountdown());
            //iframe = iframesetting;
        }
    }
    public void knockbackwithdamage(float damage,float forceX, float forceY)
    {
        if (!isDamaged)
        {
            if (knockbackright == false)
            {
                forceX = -forceX;
            }
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(forceX, forceY));
            playerhp.currentHealth -= damage;
            healthBar.SetHealth(playerhp.currentHealth);
            StartCoroutine(IframeCountdown());
            isDamagedanim = true;
        }
    }
    public void knockback(float forceX, float forceY)
    {
        if (!isDamaged)
        {
            if (knockbackright == false)
            {
                forceX = -forceX;
            }
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(forceX, forceY));
            StartCoroutine(IframeCountdown());
            isDamagedanim = true;
        }
    }
    IEnumerator IframeCountdown()
    {
        isDamaged = true;
        yield return new WaitForSeconds(iframetime);
        isDamaged = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static public int currentcheckpoint = 0;
    public CharacterController2D controller;
    public CharacterSwitch characterswitch;
    float horizontalmove = 0.0f;
    [HideInInspector]public float runspeed = 3.0f;
    public float slowrunspeed = 3.0f;
    public float normalrunspeed = 3.0f;
    public HealthBar healthBar;
    public PlayerHp playerhp;
    public bool isplayer2 = false;
    public bool knockbackright = false;

    public float iframetime = 2.5f;

    int framecountdown = 30;

    [HideInInspector] public bool isFacingright = true;
    [HideInInspector] public bool jump = false;
    public bool isMoving = false;
    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool isAirAttacking = false;
    public bool isGround = false;
    [HideInInspector] public bool isFalling = false;
    [HideInInspector] public bool isDamaged = false;
    [HideInInspector] public bool isDamagedanim = false;
    [HideInInspector] public bool ChargeAttacking = false;

    public string soundname = "xxx";
    public string Hurtsound = "Hurt";
    AudioManager audiomanager;

    void Start()
    {
        GameObject AM = GameObject.Find("AudioManager");
        audiomanager = AM.GetComponent<AudioManager>();
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
        if (ChargeAttacking)
        {
            runspeed = slowrunspeed;
        }
        else
        {
            runspeed = normalrunspeed;
        }
        if (isMoving && isGround)
        {
            if (!audiomanager.isPlaying(soundname))
            {
                audiomanager.Play(soundname);
            }
        }
        else
        {
            audiomanager.Stop(soundname);
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
                framecountdown = 50;
                isAttacking = false;
            }
        }
        else if(isAttacking == false)
        {
            framecountdown = 50;
        }
        if (isGround)
        {
            isAirAttacking = false;
        }
    }
    public void TakeDamage(float damage)
    {
        if (!isDamaged)
        {
            audiomanager.Play(Hurtsound);
            playerhp.currentHealth -= damage;
            healthBar.SetHealth(playerhp.currentHealth);
            StartCoroutine(IframeCountdown());
        }
    }
    public void knockbackwithdamage(float damage,float forceX, float forceY)
    {
        if (!isDamaged)
        {
            audiomanager.Play(Hurtsound);
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
            audiomanager.Play(Hurtsound);
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

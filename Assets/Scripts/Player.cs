using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject winUI;
    public GameObject pauseUI;
    public GameObject DieUI;
    public GameObject finish;
    public int health = 3;
    public Image[] hearts;
    public float speed = 5f;
    public float jump = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public int coins;

    private Rigidbody2D rb;
    private bool isGrounded;
    private AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip hurtClip;
    public AudioClip dieClip;
    public AudioClip killClip;
    public AudioClip winClip;

    private Animator animator;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        DieUI.SetActive(false);
        winUI.SetActive(false);
        pauseUI.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
       
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            PlaySFX(jumpClip);
        }

        SetAnimation(moveInput);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position,Vector2.down,0.3f,groundLayer);
    }
    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Run");
            }
        }
        else if (rb.velocity.y > 0)
        {
            animator.Play("Jump");
        }
        else
        {
            animator.Play("Fall");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                if(enemy.transform.position.y + 0.3f < transform.position.y)
                {
                    PlaySFX(killClip);
                    ScoreManager.AddScore(100);
                    Destroy(enemy.gameObject);
                    return;
                }
            }

            health -= 1;
            UpdateHearts();
            rb.velocity = new Vector2(rb.velocity.x, jump);
            StartCoroutine(BlinkRed());
            PlaySFX(hurtClip);

            if(health <= 0)
            {
                PlaySFX(dieClip);
                Die();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.gameObject.tag == "Finish")
        {
            PlaySFX(winClip);
            Time.timeScale = 0;
            winUI.SetActive(true);
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < health;
        }
    }



    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        Time.timeScale = 0;
        DieUI.SetActive(true);
    }

    private void PlaySFX(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}


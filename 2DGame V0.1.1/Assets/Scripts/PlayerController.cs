using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public float speed = 100;
    public float jumpForce = 250;
    private float dirX;
    public float fall = 2.5f;
    public float lowJump = 1f;
    public Vector3 spawn;
      
    private Rigidbody2D rb;

    private bool facingRight = true;

    public LevelManager gameLevelManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawn = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fall;
        }
        else if (rb.velocity.y > 0 && !CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rb.gravityScale = lowJump;
        }
        else
        {
            rb.gravityScale = 1f;
        }

        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (facingRight == false && dirX > 0)
        {
            Flip();
        }

        else if (facingRight == true && dirX < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
    void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Caida")
        {
            gameLevelManager.Reaparecer();
        }

        if (collision.tag == "Ckeckpoint")
        {
            spawn = collision.transform.position;
        }
    }
}

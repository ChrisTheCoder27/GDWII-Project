using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] UIElements uiElements;
    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip explodeSound;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;

    private bool animComplete;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            Flip();
        }

        if (uiElements.Health <= 0 || transform.position.y < -30)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Die()
    {
        PauseMenu.gameIsPaused = true;
        rb.velocity = Vector3.zero;

        explosion.SetActive(true);
        AudioSource.PlayClipAtPoint(explodeSound, transform.position);
        if (!animComplete)
        {
            StartCoroutine(ExplodeTime());
        }

        if (animComplete)
        {
            PauseMenu.gameIsPaused = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator ExplodeTime()
    {
        yield return new WaitForSeconds(0.7f);
        animComplete = true;
    }
}
using System.Diagnostics;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetpos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTIme = 0.3f;
    private float jumpTime;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, groundDistance, groundLayer);

        #region Jumping 

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;

        }
        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }
    }
}
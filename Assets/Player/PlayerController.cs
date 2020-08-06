using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Min(0)]
    public int jumpForce = 1000;
    public int walkSpeed = 10;
    [Range(0, 1)]
    public float walkSmoothing = .1f;

    private Rigidbody2D playerRigidbod;
    private Collider2D playerCollider;

    void Awake()
    {
        playerRigidbod = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 targetVelocity = new Vector2(horizontal * walkSpeed, playerRigidbod.velocity.y);
        playerRigidbod.velocity = Vector2.Lerp(playerRigidbod.velocity, targetVelocity, walkSmoothing);
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            playerRigidbod.AddForce(Vector2.up * jumpForce);
        }
    }

    private bool isGrounded() {
        var leftcast = Physics2D.Raycast(transform.position + Vector3.left * .4f + Vector3.down, Vector2.down, .1f, LayerMask.GetMask("Default"));
        var rightcast = Physics2D.Raycast(transform.position + Vector3.right * .4f + Vector3.down, Vector2.down, .1f, LayerMask.GetMask("Default"));
        return leftcast || rightcast;
    }
}

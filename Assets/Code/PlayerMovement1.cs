using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public BoxCollider2D interactCollider;
    public Animator animator;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0)
        {
            animator.SetFloat("Horizontal2", movement.x);
            interactCollider.offset = new Vector2(Mathf.Sign(movement.x) * 0.3f, 0f);
        }
        else if (movement.y != 0)
        {
            animator.SetFloat("Vertical2", movement.y);
            interactCollider.offset = new Vector2(0f, Mathf.Sign(movement.y) * 0.4f);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
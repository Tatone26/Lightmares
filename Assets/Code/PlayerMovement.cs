using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public BoxCollider2D interactCollider;
    public BoxCollider2D attackCollider;
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
            if (movement.y == 0 || (movement.y != 0 && animator.GetFloat("BaseHorizontal") != 0))
            {
                animator.SetFloat("BaseHorizontal", movement.x);
                animator.SetFloat("BaseVertical", 0f);
                interactCollider.offset = new Vector2(Mathf.Sign(movement.x) * 0.3f, 0f);
                attackCollider.offset = new Vector2(Mathf.Sign(movement.x) * 0.5f, 0f);
                attackCollider.size = new Vector2(0.4f, 1f);
            }
        }
        else if (movement.y != 0)
        {
            if (movement.x == 0 || (movement.x != 0 && animator.GetFloat("BaseVertical") != 0))
            {
                animator.SetFloat("BaseVertical", movement.y);
                animator.SetFloat("BaseHorizontal", 0f);
                interactCollider.offset = new Vector2(0f, Mathf.Sign(movement.y) * 0.3f);
                attackCollider.offset = new Vector2(0f, Mathf.Sign(movement.y) * 0.5f);
                attackCollider.size = new Vector2(1f, 0.4f);
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
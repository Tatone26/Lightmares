using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public BoxCollider2D interactCollider;
    public BoxCollider2D attackCollider_0; public Collider2D attackCollider_1; public CapsuleCollider2D attackCollider_2;
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
                attackCollider_0.offset = new Vector2(Mathf.Sign(movement.x) * 0.5f, 0f);
                attackCollider_0.size = new Vector2(0.4f, 1f);
                attackCollider_1.offset = new Vector2(Mathf.Sign(movement.x) * 0.5f, 0f);
                attackCollider_2.offset = new Vector2(Mathf.Sign(movement.x) * 1.2f, 0f);
                attackCollider_2.direction = CapsuleDirection2D.Horizontal;
                attackCollider_2.size = new Vector2(2.1f, 0.7f);
            }
        }
        else if (movement.y != 0)
        {
            if (movement.x == 0 || (movement.x != 0 && animator.GetFloat("BaseVertical") != 0))
            {
                animator.SetFloat("BaseVertical", movement.y);
                animator.SetFloat("BaseHorizontal", 0f);
                interactCollider.offset = new Vector2(0f, Mathf.Sign(movement.y) * 0.3f);
                attackCollider_0.offset = new Vector2(0f, Mathf.Sign(movement.y) * 0.5f);
                attackCollider_0.size = new Vector2(1f, 0.4f);
                attackCollider_1.offset = new Vector2(0f, Mathf.Sign(movement.y) * 0.5f);
                attackCollider_2.offset = new Vector2(0f, Mathf.Sign(movement.y) * 1.2f);
                attackCollider_2.direction = CapsuleDirection2D.Vertical;
                attackCollider_2.size = new Vector2(0.7f, 2.1f);
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
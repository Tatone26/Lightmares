using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopMovement;

    public float moveRate = 1f;
    public float moveTime = 0f;
    public float nextActionTime = 0f;

    // Start is called before the first frame Update
    void Start()
    {
        movePoint.parent = null;
    }

    Vector3 getMoveVector(string direction)
    {
        if (direction == "Vertical")
        {
            return new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        }
        else
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }
    }

    void Move(string direction) //move code
    {
        string notdir = "Horizontal";
        if (direction == "Horizontal")
        {
            notdir = "Vertical";
        }
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw(direction)) == 1f)
            {
                animator.SetFloat(direction, Input.GetAxisRaw(direction));
                animator.SetFloat(notdir, 0f);
                moveTime += Time.deltaTime;

                if (moveTime >= 0.125f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + getMoveVector(direction), .2f, whatStopMovement))
                    {
                        animator.SetFloat("Speed", 1f);
                        movePoint.position += getMoveVector(direction);
                        nextActionTime = Time.time + 0.5f / moveRate;
                    }
                }
            }
        }
    }

    //Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if ((Time.time >= nextActionTime) && (animator.GetBool("Attaque") == false))
        {
            Move("Horizontal");
            Move("Vertical");
        }
        if ((Input.GetAxisRaw("Horizontal") == 0f) && (Input.GetAxisRaw("Vertical") == 0f))
        {
            moveTime = 0;
        }
        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
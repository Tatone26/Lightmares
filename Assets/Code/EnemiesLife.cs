using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLife : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // animation de damage 
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Mort();
        }

    }

    void Mort()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);

    }
}
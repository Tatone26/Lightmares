using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnememiesLife : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }
    
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        // animation de damage a mettre

        if(currentHealth <= 0)
        {
            Mort();
        }
    }

    void Mort()
    {
        Debug.Log("Enemy died");

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

    }


}

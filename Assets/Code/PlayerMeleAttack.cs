using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleAttack : MonoBehaviour
{
    public Animator animator;

    public float attackRange = 0.4f;
    public int attackDamage = 40;
    public LayerMask ennemyLayers;

    public float attackRate = 1f;
    public float attackTime = 0f;
    public float nextActionTime = 0f;

    public Rigidbody2D rb;
    public Collider2D[] attackHitbox;
    public Collider2D attackHitbox_0; public Collider2D attackHitbox_1; public Collider2D attackHitbox_2; public Collider2D attackHitbox_3;

    public int arme = 0; //pour choisir quelle arme parce que je sais pas faire 0:dague 1:epee 2:lance 3:axe

    //Update is called once per frame
    void Update()
    {
        attackHitbox[0] = attackHitbox_0;
        attackHitbox[1] = attackHitbox_1;
        attackHitbox[2] = attackHitbox_2;
        attackHitbox[3] = attackHitbox_3;

        bool attaque = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.Alpha1)) // switch de type d'arme c'est tremporaire
        {
            arme = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            arme = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            arme = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            arme = 3;
        }

        if (Time.time >= nextActionTime)
        {
            if (animator.GetFloat("Speed") == 0)
            {
                animator.SetBool("Attaque", attaque); // Animation attaque

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    attackHitbox[arme].enabled = !attackHitbox[arme].enabled;
                    DaggerAttack();
                    nextActionTime = Time.time + 0.25f / attackRate;
                    attackHitbox[arme].enabled = !attackHitbox[arme].enabled;
                }
            }
        }
    }

    Collider2D[] getHitEnemies()
    {
        Collider2D[] hitEnemies = new Collider2D[100];
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = false;
        filter.NoFilter();
        //TODO : Filter pour filtrer ennemis UNIQUEMENT (actuelleemnt : tous boxcolliders)
        int nbHits = Physics2D.OverlapCollider(attackHitbox[arme], filter, hitEnemies);
        return hitEnemies;
    }

    void DaggerAttack()
    {
        Collider2D[] hitEnemies = getHitEnemies();
        if (hitEnemies != null)
        {
            foreach (Collider2D enemyHitbox in hitEnemies)
            {
                if (enemyHitbox != null)
                {
                    Debug.Log(enemyHitbox);
                    GameObject enemyObject = enemyHitbox.gameObject;
                    if (enemyObject != null && enemyObject.tag == "Enemy")
                    {
                        EnemiesLife enemyScript = enemyObject.GetComponent<EnemiesLife>();
                        if (enemyScript != null)
                        {
                            enemyScript.TakeDamage(attackDamage);
                        }
                    }
                }
            }
        }
    }
}


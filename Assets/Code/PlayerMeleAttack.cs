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
        //attackPoint.position = rb.position + new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));

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




    //void DaggerAttack()
    //{
    //    // Hitbox de l'attaque
    //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ennemyLayers);
    //    // infligeage des damage
    //    foreach (Collider2D enemy in hitEnemies)
    //    {
    //        Debug.Log("Touché");
    //        enemy.GetComponent<EnememiesLife>().TakeDamage(attackDamage);
    //    }
    //}

    //void SwordAttack () {
    //Vector3 direction = transform.TransformDirection(animator.GetFloat("Vertical"), animator.GetFloat("Horizontal"), 0f);
    //RaycastHit2D[] hitEnemies = Physics2D.RaycastAll(attackPoint.position - direction, direction*2, ennemyLayers);

    //foreach (RaycastHit2D enemy in hitEnemies)
    //{
    //Debug.Log ("Touché");
    //enemy.GetComponent<EnememiesLife>().TakeDamage(attackDamage);
    //}
    //}

    //void SpearAttack() {
    //Vector3 direction = transform.TransformDirection(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"), 0f);
    //RaycastHit2D[] hitEnemies = Physics2D.RaycastAll(attackPoint.position, direction);

    //foreach (RaycastHit2D enemy in hitEnemies)
    //{
    //Debug.Log ("Touché");
    //enemy.GetComponent<EnememiesLife>().TakeDamage(attackDamage);
    //}
    //}

    //void AxeAttack()
    //{
    //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rb.position, attackRange * 3, ennemyLayers);
    //    foreach (Collider2D enemy in hitEnemies)
    //    {
    //        Debug.Log("Touché");
    //        enemy.GetComponent<EnememiesLife>().TakeDamage(attackDamage);
    //    }
    //}

    //void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null)
    //        return;

    //    //Vector3 direction = transform.TransformDirection(animator.GetFloat("Vertical"), animator.GetFloat("Horizontal"), 0f); // épée
    //    //Gizmos.DrawRay(attackPoint.position - direction, direction*2);

    //    //Vector3 direction = transform.TransformDirection(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"), 0f); // Lance
    //    //Gizmos.DrawRay(attackPoint.position, direction);

    //    Gizmos.DrawWireSphere(rb.position, attackRange * 3); //hache

    //    //Gizmos.DrawWireSphere(attackPoint.position, attackRange); // Dague
    //}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleAttack : MonoBehaviour
{
  public Animator animator ;
  public Transform attackPoint;
  public float attackRange = 0.4f;
  public int attackDamage = 40;
  public LayerMask ennemyLayers;
  public Transform movePoint;

  public float attackRate = 1f;
  public float attackTime = 0f;
  public float nextActionTime = 0f;


  //Update is called once per frame
  void Update()
  {
    bool attaque = Input.GetKeyDown(KeyCode.Mouse0);
    attackPoint.position = movePoint.position + new Vector3(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"), 0f);

    if (Time.time >= nextActionTime){

      if (animator.GetFloat("Speed") == 0){
        animator.SetBool("Attaque", attaque); // Animation attaque

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
          DaggerAttack();
          nextActionTime = Time.time + 0.25f / attackRate;
        }
      }
    }
    
  }

  void DaggerAttack () {
    // Hitbox de l'attaque
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ennemyLayers);
    // infligeage des damage
    foreach (Collider2D enemy in hitEnemies) 
    {
      Debug.Log ("Touché");
      enemy.GetComponent<EnememiesLife>().TakeDamage(attackDamage);
    }
          
  }

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
  
  void AxeAttack() {
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(movePoint.position, attackRange*3, ennemyLayers);
    foreach (Collider2D enemy in hitEnemies) 
    {
     Debug.Log ("Touché");
     enemy.GetComponent<EnememiesLife>().TakeDamage(attackDamage);
    }
  }
  
  void OnDrawGizmosSelected ()
  {
    if (attackPoint == null)
      return;
    
    //Vector3 direction = transform.TransformDirection(animator.GetFloat("Vertical"), animator.GetFloat("Horizontal"), 0f); // épée
    //Gizmos.DrawRay(attackPoint.position - direction, direction*2);

    //Vector3 direction = transform.TransformDirection(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"), 0f); // Lance
    //Gizmos.DrawRay(attackPoint.position, direction);

    Gizmos.DrawWireSphere (movePoint.position, attackRange*3); //hache
    
    //Gizmos.DrawWireSphere(attackPoint.position, attackRange); // Dague
  }

  

 


}


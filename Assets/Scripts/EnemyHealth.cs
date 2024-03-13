using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public Animator animator;
    public Explosion explosionPrefab;
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }
    private void EnemyDeath()
    {
        animator.SetTrigger("Death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke("Explosion", 3);
    }
    void Explosion()
    {
        Instantiate(explosionPrefab);
        explosionPrefab.transform.position = transform.position;
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public Animator animator;
    public Explosion explosionPrefab;
    public Transform explosionParticle;
    public PlayerProgress playerProgress;
    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }
    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);
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
        Invoke("Explosion", 3);
        animator.SetTrigger("Death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
    void Explosion()
    {
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        var explosionPart = Instantiate(explosionParticle);
        explosionPart.transform.position = transform.position;
        Destroy(gameObject);
    }
}

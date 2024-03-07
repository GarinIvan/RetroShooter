using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrulPoint;
    private NavMeshAgent _navMeshAgent;
    public PlayerController player;
    private bool _isPlayerNoticed;
    public float viewAngle;
    public float damage = 30;
    private PlayerHealth _playerHealth;
    public Animator animator;
    void Start()
    {
        InitComponentLinks();
        PatrolUpdate();
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttakUpdate();
        PatrolUpdate();
    }
    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;
        if (_playerHealth.health <= 0) return;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void AttakUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("Attack");
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }
    private void PatrolUpdate()
    {
        if(!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.destination = patrulPoint[Random.Range(0, patrulPoint.Count)].position;
            }
        }
    }
}

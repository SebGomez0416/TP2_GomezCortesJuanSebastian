using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private float life;
    [SerializeField] private GameObject coin;
    private Animator _animator;
    [SerializeField] private float timeToDestroy;
    private Transform target;
    private NavMeshAgent agent;
    [SerializeField] private bool tutorial;
    private float damage;
    
    public Transform Target
    {
        get => target;
        set => target = value;
    }

    private void Awake()
    {
        damage = 1;
        _animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (tutorial ) return ;
        agent.SetDestination(target.position);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0) Die();
    }

    private void Attack()
    {
        agent.isStopped = true;
        _animator.SetTrigger("Attack");
    }
    private void Die()
    {
        agent.isStopped = true;
        _animator.SetTrigger("Dying");
        Invoke("SpawnCoin",timeToDestroy);
        Destroy(gameObject,timeToDestroy);
    }

    private void SpawnCoin()
    {
        Instantiate(coin,transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider o)
    {
        if (!o.gameObject.CompareTag("Player")) return;
        var obj = o.gameObject.GetComponent<IDamageable>();
        obj?.TakeDamage(damage);
        Attack();
    }

    private void OnTriggerExit(Collider o)
    {
        if (!o.gameObject.CompareTag("Player")) return;
        agent.isStopped = false;
        _animator.SetTrigger("Run");
    }

   


   
}

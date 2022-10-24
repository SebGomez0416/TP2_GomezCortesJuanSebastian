using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private float life;
    [SerializeField] private GameObject coin;
    private Animator _animator;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    [SerializeField] private bool tutorial;
    private bool IsDead;
    
    
    
    private void Awake()
    {
        IsDead = false;
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
}

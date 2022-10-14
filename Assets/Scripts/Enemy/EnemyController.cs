using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private float life;
    private Animator _animator;
    [SerializeField] private float timeToDestroy;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        if(life<=0) Die();
    }
    
    private void Die()
    {
        _animator.SetTrigger("Dying");
        Destroy(gameObject,timeToDestroy);
    }
}

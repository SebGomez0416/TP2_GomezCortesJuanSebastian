using UnityEngine;

public class EndTutorial : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject ScreenFinish;
    private Animator _animator;
    private float timeToDestroy;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        timeToDestroy = 3.1f;
    }

    public void TakeDamage(float damage)
    {
        _animator.SetTrigger("Dying");
        Destroy(gameObject,timeToDestroy);
        Invoke("Finish",2);
    }
    private void Finish()
    {
        ScreenFinish.SetActive(true);
    }

    
}

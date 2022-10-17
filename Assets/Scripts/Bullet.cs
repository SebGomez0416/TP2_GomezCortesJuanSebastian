using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;


    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Enemy") )
        {
            var obj = c.gameObject.GetComponent<IDamageable>();
            obj?.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (c.gameObject.CompareTag("Level") ) Destroy(gameObject);
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;


    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag != "Enemy") return;
        var obj = c.gameObject.GetComponent<IDamageable>();
        obj?.TakeDamage(damage);
        Destroy(gameObject);
    }
}

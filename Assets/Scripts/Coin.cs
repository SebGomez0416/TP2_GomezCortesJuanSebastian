using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speedRotation;

    public static event Action OnSendCoin;

    private void Update()
    {
       transform.Rotate(Vector3.up * (speedRotation * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider c)
    {
        if (!c.gameObject.CompareTag("Player")) return;
        OnSendCoin?.Invoke();
        Destroy(gameObject);
    }
}

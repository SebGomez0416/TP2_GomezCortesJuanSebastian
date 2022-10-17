using System;
using UnityEngine;

public class Tip : MonoBehaviour
{
    [SerializeField] private GameObject ScreenTip;
    
    public static event Action OnTutorial;
    
    private void OnTriggerEnter(Collider c)
    {
        if (!c.gameObject.CompareTag("Player")) return;
        OnTutorial?.Invoke();
        ScreenTip.SetActive(true);
        Destroy(gameObject);
    }
}

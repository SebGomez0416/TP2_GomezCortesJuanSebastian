using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTutorial : MonoBehaviour
{
    public static event Action OnTutorial;

    public void Next()
    {
        gameObject.SetActive(false);
        OnTutorial?.Invoke();
    }
    
    public void Finish()
    {
        SceneManager.LoadScene("Gameplay");
    }
}

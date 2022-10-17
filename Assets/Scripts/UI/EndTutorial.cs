using System;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    [SerializeField] private GameObject ScreenFinish;

    private void OnDestroy()
    {
        ScreenFinish.SetActive(true);
    }
}

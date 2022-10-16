using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    [SerializeField] private Image barOne;
    [SerializeField] private Image barTwo;
    [SerializeField] private Image barThree;
    private int currenLife;

    private void Awake()
    {
        currenLife = 3;
    }

    private void OnEnable()
    {
        PlayerController.OnSendDamage += UpdateLife;
    }

    private void OnDisable()
    {
        PlayerController.OnSendDamage -= UpdateLife;
    }

    private void Update()
    {
      transform.rotation= Quaternion.Euler(0,0,0);
    }

    private void UpdateLife()
    {
        currenLife--;

        switch (currenLife)
        {
            case 0:
                barOne.enabled = false;
                //moriste 
                break;
            case 1:
                barTwo.enabled = false;
                break;
            case 2:
                barThree.enabled = false;
                break;
            
        }
    }
}

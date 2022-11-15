using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins;
    private int currentCoins;

    private void Awake()
    {
        currentCoins = 0;
        coins.text = "" + currentCoins;
        
    }
    
    private void OnEnable()
    {
        Coin.OnSendCoin += UpdateCoins;
    }

    private void OnDisable()
    {
        Coin.OnSendCoin -= UpdateCoins;
    }

    private void UpdateCoins()
    {
        currentCoins++;
        coins.text =""+ currentCoins;
    }

    public void Skip()
    {
        SceneManager.LoadScene("Gameplay");
    }
}

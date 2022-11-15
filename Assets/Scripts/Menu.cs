using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   [SerializeField] private GameObject ScreenOptions;
   [SerializeField] private GameObject ScreenStore;
   private bool options;
   private bool store;

   private void Awake()
   {
      options = false;
      store = false;
   }

   public void Play()
   {
      SceneManager.LoadScene("Tutorial");
   }
   
   public void Options()
   {
      options = !options;
      ScreenOptions.SetActive(options);
   }
   
   public void Store()
   {
      store = !store;
      ScreenOptions.SetActive(store);
      
   }
   
}

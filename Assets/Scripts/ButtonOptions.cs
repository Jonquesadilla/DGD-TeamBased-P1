using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonOptions : MonoBehaviour
{
   public void Menu()
   {
      SceneManager.LoadScene(0);
   }
   public void Play()
   {
      SceneManager.LoadScene(1);
   }
   public void Quit()
   {
      Application.Quit();
   }
   public void Instructions()
   {
      SceneManager.LoadScene(2);
   }
}

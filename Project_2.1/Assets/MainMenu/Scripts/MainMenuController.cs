
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void StartGame(int sceneNumber)
   {
      SceneManager.LoadScene(sceneNumber);
   }

   public void ExitGame()
   {
      Application.Quit();
   }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuBehaviour : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

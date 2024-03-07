using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public string levelToLoad = "StartMenu"; 

    public void StartGame()
    {
        // Oyun sahnesini yükle
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        // Oyundan çıkış yap
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void VsComputer()
    {
        SceneManager.LoadSceneAsync(2);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void LocalMultiplayer()
    {
        SceneManager.LoadSceneAsync(3);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
    
    public void OnlineMultiplayer()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

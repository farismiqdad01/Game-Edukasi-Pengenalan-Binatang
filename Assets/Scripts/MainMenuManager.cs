using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject ensiklopedia;
    private GameObject gamePlay;
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenEnsiklopedia()
    {
        mainMenu.SetActive(false);
        ensiklopedia.SetActive(true);
    }
}

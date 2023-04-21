using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonExit : MonoBehaviour
{
    public Canvas MainMenu;
    public GameObject multiplay;
    public void Exit()
    {
        Application.Quit();
    }
    public void NewGame(int _scene)
    {
        PlayerPrefs.SetFloat("PosX", 0);
        PlayerPrefs.SetFloat("PosZ", 0);
        PlayerPrefs.SetFloat("PosY", 0);
        SceneManager.LoadScene(_scene);
    }

    public void Multiplay()
    {
        MainMenu.gameObject.SetActive(false);
        multiplay.SetActive(true);
    }

    public void ReturnTomMainPage()
    {

        MainMenu.gameObject.SetActive(true);
        multiplay.gameObject.SetActive(false);
    }
}

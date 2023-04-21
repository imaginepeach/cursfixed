using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameField;
    private void Awake()
    {
        startMenu.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exist, destroying object!");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        startMenu.SetActive(false);
        usernameField.interactable = false;
        SceneManager.LoadScene(3);
        Client.instance.ConnectedToServer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    int _scene;
    Transform PlayerPos;
    public void Save()
    {
        PlayerPrefs.SetFloat("PosX", PlayerPos.transform.position.x);
        PlayerPrefs.SetFloat("PosZ", PlayerPos.transform.position.z);
        PlayerPrefs.SetFloat("PosY", PlayerPos.transform.position.y);
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
    }
    private void Awake()
    {
        PlayerPos = transform;
    }
    public void Load()
    {
        Transform CurrentPlayerPosition = this.gameObject.transform;
        if (SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("Scene"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));
        }
        Vector3 PlayerPosition = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
        CurrentPlayerPosition.position = PlayerPosition;
    }
}

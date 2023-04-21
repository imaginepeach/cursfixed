using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class EscapeMenu : MonoBehaviour
{
    public CinemachineVirtualCamera CVC;
    bool isActive = false;
    public GameObject EscapeMenuCanvas;
    // Start is called before the first frame update
    void Awake()
    {
        EscapeMenuCanvas.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            if (isActive)
            {
                EscapeMenuCanvas.SetActive(true);
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                EscapeMenuCanvas.SetActive(false);
                CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
                CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    public void Resume()
    {
        EscapeMenuCanvas.gameObject.SetActive(false);
        isActive = false;
    }
    public void GoToMainMenu(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }
}

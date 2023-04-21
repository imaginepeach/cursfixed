using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Mage : MonoBehaviour
{
    public GameObject inv;
    CinemachineVirtualCamera CVC;
    public bool isOpen;

    private void Start()
    {
        inv.SetActive(false);
    }

    private void OnLevelWasLoaded(int level)
    {
        inv.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                if (isOpen)
                {
                    inv.SetActive(true);
                    CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
                    CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    inv.SetActive(false);
                    CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
                    CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isOpen)
        {
            isOpen = !isOpen;
        }
        inv.SetActive(false);
        CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
        CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        CVC = FindFirstObjectByType<CinemachineVirtualCamera>();
    }
}

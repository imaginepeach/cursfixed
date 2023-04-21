using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inv;
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool isOpen;
    private Camera mainCamera;
    public float reachDist = 2f;
    public CinemachineVirtualCamera CVC;

    private void Awake()
    {
        inv.SetActive(true);
    }
    void Start()
    {
        mainCamera = Camera.main;
        inv.SetActive(false);
        for (int i = 0; i<InventoryPanel.childCount; i++)
        {
            if (InventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null && InventoryPanel.GetChild(i).tag != "Equip")
            {
                slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
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
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDist))
            {
                if (hit.collider.GetComponent<Item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    private void AddItem(ItemSriptebleObject _item, int _amount)
    {
        foreach(InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.MaxAmout)
                {
                    slot.amount += _amount;
                    slot.itemAmount.text = slot.amount.ToString();
                    return;
                }
                break;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if(slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmount.text = _amount.ToString();
                return;
            }
        }
    }
}

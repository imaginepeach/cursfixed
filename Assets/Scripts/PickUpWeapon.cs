using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    GameObject offWeapon;
    ItemSriptebleObject weapon;
    GameObject currentWeapon;
    public GameObject Inventory;
    bool isEquip = false;
    // Update is called once per frame

    private void Update()
    {
        if (Inventory.transform.GetChild(15).GetComponent<InventorySlot>().isEmpty == false && isEquip == false)
        {
            isEquip = true;
            weapon = Inventory.transform.GetChild(15).GetComponent<InventorySlot>().item;
            PickUp();
        }
        if(Inventory.transform.GetChild(15).GetComponent<InventorySlot>().isEmpty == true && isEquip == true)
        {
            offWeapon = transform.GetChild(0).gameObject;
            Destroy(offWeapon);
            isEquip = false;
        }
    }
    void PickUp()
    {
        currentWeapon = Instantiate(weapon.itemPrefab);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
        currentWeapon.GetComponent<Collider>().isTrigger = true;
        currentWeapon.transform.parent = transform;
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
    }
}

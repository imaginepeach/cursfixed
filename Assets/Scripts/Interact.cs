using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    GameObject currentNPC;
    public float distance = 15f;
    bool a = false;
    public AudioClip din;
    AudioSource audio;
    void Start()
    {
     
    }

    void Inter()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "NPC")
            {
                currentNPC = hit.transform.gameObject;
                audio = currentNPC.GetComponent<AudioSource>();
                audio.Play();
            }
        }
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Inter();
    }
}

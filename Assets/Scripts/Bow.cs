using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Vector3 dir;
    public GameObject arrowPref;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (transform.IsChildOf(GameObject.Find("Hand").transform))
        {
            transform.parent.GetComponent<attackscript>().enabled = false;
            if (Input.GetMouseButtonDown(0))
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().arrow > 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().arrow--;
                    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    RaycastHit hit;

                    Vector3 target;
                    if (Physics.Raycast(ray, out hit))
                        target = hit.point;
                    else
                        target = ray.GetPoint(90);
                    dir = target - transform.GetChild(1).position;
                    GameObject currentArrow = Instantiate(arrowPref, transform.GetChild(1).position, Quaternion.identity);
                    currentArrow.transform.forward = dir.normalized;
                    currentArrow.GetComponent<Rigidbody>().AddForce(dir.normalized * 2000, ForceMode.Force);
                }
            }
        }
    }
}

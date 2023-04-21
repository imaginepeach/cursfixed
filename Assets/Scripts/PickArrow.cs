using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickArrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerClass>().arrow++;
            Destroy(gameObject);
        }
    }
}

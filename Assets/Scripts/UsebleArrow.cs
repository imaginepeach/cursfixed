using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsebleArrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyScript>().TakeDamage(20);
            Destroy(transform.gameObject);
        }

    }
}

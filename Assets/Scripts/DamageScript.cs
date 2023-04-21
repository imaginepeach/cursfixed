using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float damageAmount;
    public WeponItem wepon;

    private void Start()
    {
        damageAmount = wepon.damage; //reflection class - посмотреть
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
    }
    private void Update()
    {
        if(transform.IsChildOf(GameObject.Find("Hand").transform))
        {
            transform.parent.GetComponent<attackscript>().enabled = true;
        }
    }
}

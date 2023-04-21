using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class PlayerManager : MonoBehaviour
{
    float _attackDelay = 0;
    Collider col;
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(_attackDelay < other.transform.GetComponent<DamageScriptEnemy>().attackSpeed)
            {
                _attackDelay += Time.deltaTime;
            }
            else
            {
                _attackDelay = 0;
                TakeDamage(other);
            }
        }
    }

    private void TakeDamage(Collider col)
    {
        if (col.transform.GetComponent<DamageScriptEnemy>().damageCount - transform.gameObject.GetComponent<PlayerClass>().armor > 0)
        {
            transform.gameObject.GetComponent<PlayerClass>().HP -= col.transform.GetComponent<DamageScriptEnemy>().damageCount - transform.gameObject.GetComponent<PlayerClass>().armor;
        }
    }
}

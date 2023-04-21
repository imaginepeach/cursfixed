using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    public void AddPointToMaxHP()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SkillPoint > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SkillPoint--;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().MaxHP *= 1.25f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().HP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().MaxHP;
        }
    }
    public void AddPointToSpeed()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SkillPoint > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SkillPoint--;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SpeedMult *= 1.1f;
        }
    }
    public void AddPointToDamage()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SkillPoint > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().SkillPoint--;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().DamageMult *= 1.15f;
        }
    }
}

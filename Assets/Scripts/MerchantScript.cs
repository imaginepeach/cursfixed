using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantScript : MonoBehaviour
{
    public GameObject[] prefabs;
    public void buyArrow()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold >= 3)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold -= 3;
            Instantiate(prefabs[0], GameObject.Find("MerchantSpawnBuy").transform.position, GameObject.Find("MerchantSpawnBuy").transform.rotation);
        }
    }
    public void buyBow()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold >= 300)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold -= 300;
            Instantiate(prefabs[4], GameObject.Find("MerchantSpawnBuy").transform.position, GameObject.Find("MerchantSpawnBuy").transform.rotation);
        }
    }
    public void buySword1()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold >= 30)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold -= 30;
            Instantiate(prefabs[1], GameObject.Find("MerchantSpawnBuy").transform.position, GameObject.Find("MerchantSpawnBuy").transform.rotation);
        }
    }
    public void buySword2()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold >= 250)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold -= 250;
            Instantiate(prefabs[2], GameObject.Find("MerchantSpawnBuy").transform.position, GameObject.Find("MerchantSpawnBuy").transform.rotation);
        }
    }
    public void buySword3()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold >= 750)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold -= 750;
            Instantiate(prefabs[3], GameObject.Find("MerchantSpawnBuy").transform.position, GameObject.Find("MerchantSpawnBuy").transform.rotation);
        }
    }
    public void buyArtifact()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold >= 5000)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>().gold -= 5000;
            Instantiate(prefabs[5], GameObject.Find("MerchantSpawnBuy").transform.position, GameObject.Find("MerchantSpawnBuy").transform.rotation);
        }
    }
}

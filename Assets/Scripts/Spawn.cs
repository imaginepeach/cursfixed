using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    bool NewGame = true;
    public GameObject player;
    private void OnLevelWasLoaded(int level)
    {
        if (level != 1)
        {
            NewGame = false;
        }
        if (NewGame)
        {
            Instantiate(player, transform.position, transform.rotation);
            NewGame = false;
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = transform.position;
        }
    }
    private void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            Destroy(players[0]);
        }
    }
}

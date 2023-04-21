using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, ManagerPlayer> players = new Dictionary<int, ManagerPlayer>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exist, destroying object!");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if(_id == Client.instance.myID)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<ManagerPlayer>().id = _id;
        _player.GetComponent<ManagerPlayer>().username = _username;
        players.Add(_id, _player.GetComponent<ManagerPlayer>());
    }
}

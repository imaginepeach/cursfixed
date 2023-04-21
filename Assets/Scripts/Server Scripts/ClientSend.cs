using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUPDData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myID);
            _packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(_packet);
        }
    }

    public static void PlayerMovement(bool[] _inputs)
    {
        using(Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);

            foreach (bool input in _inputs)
            {
                _packet.Write(input);
            }
            _packet.Write(GameManager.players[Client.instance.myID].transform.rotation);

            SendUPDData(_packet);
        }
    }
    #endregion
}

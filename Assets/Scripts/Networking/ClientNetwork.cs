using UnityEngine;
using UnityEngine.Networking;

public class ClientNetwork : MonoBehaviour {
    private NetworkClient myClient;

    public void Start()
    {
        StartClient();
    }

    public void StartClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.RegisterHandler(MsgType.Disconnect, OnDisconnected);
        myClient.Connect("127.0.0.1", ServerNetwork.SERVER_PORT);
    }

    public void Disconnect()
    {
        myClient.Disconnect();
    }

    private void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server successfully!");
    }

    private void OnDisconnected(NetworkMessage netMsg)
    {
        Debug.Log("Disconnected from server");
    }
}

using UnityEngine;
using UnityEngine.Networking;

public class ServerNetwork : MonoBehaviour {
    public const int SERVER_PORT = 4444;

    public GameObject startServerBtn, stopServerBtn;

    public void StartServer()
    {
        if(NetworkServer.Listen(SERVER_PORT))
        {
            Debug.Log("Server started at port " + SERVER_PORT);
            startServerBtn.SetActive(false);
            stopServerBtn.SetActive(true);
        }
    }

    public void StopServer()
    {
        NetworkServer.Shutdown();
        Debug.Log("Server stopped");

        startServerBtn.SetActive(true);
        stopServerBtn.SetActive(false);
    }
}

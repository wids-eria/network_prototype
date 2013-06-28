using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
    public int number_of_players = 32;
    public int port_number = 25000;
    public string password = "a password";

    public Spawny spawner; // TODO use dynamics or link to parent instead for less coupling


    // SERVER

    public void launch_server()
    {
        Network.incomingPassword = password;
        bool use_nat = !Network.HavePublicAddress();
        Network.InitializeServer(number_of_players, port_number, use_nat);
    }


    void OnServerInitialized()  { Debug.Log ("Server Initialized."); }

    void OnPlayerDisconnected() { Debug.Log ("Player Disconnected"); }

    void OnPlayerConnected()    { Debug.Log ("Player Connected");    }



    // CLIENT

    public void connect_to(string server_host) {
        Network.Connect(server_host, port_number, password);
    }

    void OnConnectedToServer()      { Debug.Log ("Connected to server"); spawner.request_all_objects(); }

    void OnDisconnectedFromServer() { Debug.Log ("Disconnected from server"); }
}

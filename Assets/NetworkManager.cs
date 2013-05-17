using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
    public int number_of_players = 32;
    public int port_number = 25000;
    public string password = "a password";

    // SERVER

    public void launch_server()
    {
        Network.incomingPassword = password;
        bool use_nat = !Network.HavePublicAddress();
        Network.InitializeServer(number_of_players, port_number, use_nat);
    }


    void OnServerInitialized()
    {
        Debug.Log("The server is successfully initialized.");
    }



    // CLIENT

    public void connect_to(string server_host) {

    }
}

using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    // SERVER

    public void launch_server()
    {
        Network.incomingPassword = "a password";
        bool use_nat = !Network.HavePublicAddress();
        Network.InitializeServer(32, 25000, use_nat);
    }


    void OnServerInitialized()
    {
        Debug.Log("The server is successfully initialized.");
    }



    // CLIENT
}

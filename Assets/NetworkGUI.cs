using UnityEngine;
using System.Collections;

public class NetworkGUI : MonoBehaviour {
  public string connect_host = "127.0.0.1"; // Store in player prefs

  public GUIStyle guiPixelBoxStyle;
  public GUIStyle guiDropShadowStyle;
  public GUIStyle guiMineBoxStyle;

  public NetworkManager network_manager;


  void OnGUI () {
    GUILayout.BeginArea (new Rect (10, 10, 200, 150), guiPixelBoxStyle);

      if(GUILayout.Button ("Host",    guiMineBoxStyle)) { network_manager.launch_server(); }
      if(GUILayout.Button ("Connect", guiMineBoxStyle)) { Debug.Log("connect click"); }

      connect_host = GUILayout.TextField (connect_host, guiDropShadowStyle);

    GUILayout.EndArea ();
  }
}

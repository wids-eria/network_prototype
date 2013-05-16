using UnityEngine;
using System.Collections;

public class NetworkGUI : MonoBehaviour {
  void OnGUI () {
    GUILayout.BeginArea (new Rect (10, 10, 100, 100));

      GUILayout.Button ("Client");
      GUILayout.Button ("Server");

    GUILayout.EndArea ();
  }
}

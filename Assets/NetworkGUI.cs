using UnityEngine;
using System.Collections;

public class NetworkGUI : MonoBehaviour {
  public GUIStyle guiPixelBoxStyle;

  void OnGUI () {
    GUILayout.BeginArea (new Rect (10, 10, 100, 100), guiPixelBoxStyle);

      GUILayout.Button ("Client");
      GUILayout.Button ("Server");

    GUILayout.EndArea ();
  }
}

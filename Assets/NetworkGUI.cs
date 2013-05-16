using UnityEngine;
using System.Collections;

public class NetworkGUI : MonoBehaviour {
  public GUIStyle guiPixelBoxStyle;
  public GUIStyle guiDropShadowStyle;

  void OnGUI () {
    GUILayout.BeginArea (new Rect (10, 10, 200, 150), guiPixelBoxStyle);

      GUILayout.Button ("Host");
      GUILayout.Button ("Connect");
      GUILayout.TextField("127.0.0.1", guiDropShadowStyle);

    GUILayout.EndArea ();
  }
}

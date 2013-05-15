using UnityEngine;
using System.Collections;

public class Spawny : MonoBehaviour {
  public GameObject prefabulous;


  // Update is called once per frame
  void Update () {
    if(Input.GetButtonDown("Fire1")) {
      Instantiate (prefabulous, new Vector3(0, 0, 0), Quaternion.identity);
    }
  }
}

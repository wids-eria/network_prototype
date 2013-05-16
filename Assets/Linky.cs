using UnityEngine;
using System.Collections;

public class Linky : MonoBehaviour {

  // Update is called once per frame
  void Update () {
    if(Input.GetButtonDown("Fire2")) {

      Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
      RaycastHit hit;

      if( Physics.Raycast( ray, out hit, 100 ) ) {

        Debug.Log( hit.transform.gameObject.name );
      }
    }
  }
}

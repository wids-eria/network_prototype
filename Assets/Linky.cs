using UnityEngine;
using System.Collections;

public class Linky : MonoBehaviour {
  GameObject first_pick;
  public Spawny spawner; // FIXME remove coupling, dynamic find from parent game manager soul (or global?)

  // Update is called once per frame
  void Update () {
    if(Input.GetButtonDown("Fire2")) {

      Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
      RaycastHit hit;

      if( Physics.Raycast( ray, out hit, 100 ) ) {

        GameObject selected_object = hit.transform.gameObject;

        if(!first_pick) {
          first_pick = selected_object;
        }
        else {
          GameObject second_pick = selected_object;

          second_pick.renderer.material = first_pick.renderer.material;

          spawner.request_color_change(second_pick, first_pick.renderer.material.GetColor("_Color"));

          first_pick = null;
        }
      }
    }
  }
}

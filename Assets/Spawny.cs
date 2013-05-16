using UnityEngine;
using System.Collections;

public class Spawny : MonoBehaviour {
  public GameObject prefabulous;
  public GameObject spawn_point;


  // Update is called once per frame
  void Update () {
    if(Input.GetButtonDown("Fire1")) {
      GameObject new_thing = (GameObject)Instantiate (prefabulous, spawn_point.transform.position, Quaternion.identity);

      if (Random.value > 0.5) {
        new_thing.renderer.material.SetColor("_Color", new Color(Random.value, Random.value, Random.value));
      }
      else if (Random.value > 0.5F) {
        Material thing2 = (Material)Instantiate(Resources.Load("Thing2"));
        new_thing.renderer.material = thing2;
        new_thing.transform.localScale += new Vector3(0.5F,0.5F,0.5F);

      }
    }
  }
}

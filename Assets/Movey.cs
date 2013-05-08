using UnityEngine;
using System.Collections;

public class Movey : MonoBehaviour {

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    if (Input.GetKey(KeyCode.W)) {
      //transform.RotateAround(transform.up, sweetshit * Time.deltaTime);
      rigidbody.AddRelativeTorque (Vector3.forward * 60);
    }

    if (Input.GetKey(KeyCode.Q)) {
      rigidbody.AddTorque (Vector3.up * -30);
    }

    if (Input.GetKey(KeyCode.E)) {
      rigidbody.AddTorque (Vector3.up * 30);
    }
  }
}

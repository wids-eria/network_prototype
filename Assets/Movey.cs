using UnityEngine;
using System.Collections;

public class Movey : MonoBehaviour {


  // Update is called once per frame
  void Update () {
    rigidbody.AddRelativeTorque (Vector3.forward * 60 * Input.GetAxis("Vertical")  );
    rigidbody.AddTorque         (Vector3.up      * 30 * Input.GetAxis("Horizontal"));

    if(Input.GetButtonDown("Jump")) {
      rigidbody.AddForce (Vector3.up * 400);
    }
  }
}

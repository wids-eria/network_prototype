using UnityEngine;
using System.Collections;

public class Movey : MonoBehaviour {
  public int forward_speed = 60;
  public int turning_force = 30;
  public int jumping_force = 400;


  // Update is called once per frame
  void Update () {
    rigidbody.AddRelativeTorque (Vector3.forward * forward_speed * Input.GetAxis("Vertical")  );
    rigidbody.AddTorque         (Vector3.up      * turning_force * Input.GetAxis("Horizontal"));

    if(Input.GetButtonDown("Jump")) {
      rigidbody.AddForce (Vector3.up * jumping_force);
    }
  }
}

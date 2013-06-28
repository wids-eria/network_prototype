using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawny : MonoBehaviour {
  public GameObject prefabulous;
  public GameObject spawn_point;

  public List<GameObject> game_objects;


  void Start () {
    game_objects = new List<GameObject>();
    Messenger<float>.AddListener ("spawn all the things", OnSpawnThings);
    Messenger<float>.Broadcast   ("spawn all the things", 14.5F);
  }

  void OnSpawnThings(float spawny)
  {
    Debug.Log("spawny: "+spawny);
  }

  // Update is called once per frame
  void Update () {
    if(Input.GetButtonDown("Fire3")) {

      Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
      RaycastHit hit;

      if( Physics.Raycast( ray, out hit, 100 ) ) {

        // GameObject new_thing = (GameObject)Instantiate (prefabulous, spawn_point.transform.position, Quaternion.identity);
        GameObject new_thing = (GameObject)Instantiate (prefabulous, hit.point + (Vector3.up * 0.5F), Quaternion.LookRotation(hit.normal));

        if (Random.value > 0.5) {
          new_thing.renderer.material.SetColor("_Color", new Color(Random.value, Random.value, Random.value));
        }
        else if (Random.value > 0.5F) {
          Material thing2 = (Material)Instantiate(Resources.Load("Thing2"));
          new_thing.renderer.material = thing2;
          new_thing.transform.localScale += new Vector3(0.5F,0.5F,0.5F);

        }

        game_objects.Add(new_thing);

        NetworkViewID view_id = Network.AllocateViewID();
        NetworkView network_view = new_thing.GetComponent<NetworkView>();
        network_view.viewID = view_id;

        Color color = new_thing.renderer.material.GetColor("_Color");
        Vector3 color_vec = new Vector3(color.r, color.g, color.b);
        networkView.RPC("spawn_object", RPCMode.All, view_id, new_thing.transform.position, new_thing.transform.localScale, new_thing.transform.rotation, color_vec);
      }
    }
  }


  public void request_all_objects() {
    networkView.RPC("send_all_objects", RPCMode.Server);
  }

  [RPC]
  void send_all_objects(NetworkMessageInfo info) {
    foreach(GameObject game_object in game_objects) {
      NetworkView network_view = game_object.GetComponent<NetworkView>();

      Color color = game_object.renderer.material.GetColor("_Color");
      Vector3 color_vec = new Vector3(color.r, color.g, color.b);

      networkView.RPC("spawn_object", info.sender, network_view.viewID, game_object.transform.position, game_object.transform.localScale, game_object.transform.rotation, color_vec);
    }
  }


  [RPC]
  void spawn_object(NetworkViewID view_id, Vector3 location, Vector3 scale, Quaternion rotation, Vector3 color, NetworkMessageInfo info) {
    Debug.Log("RPC ** spawn_object sender:"+info.sender);

    // TODO some concept of player id/owner/networkplayer
    foreach(GameObject game_object in game_objects) {
      NetworkView network_view = game_object.GetComponent<NetworkView>();
      if(network_view.viewID == view_id) {
        return;
      }
    }

    GameObject new_thing = (GameObject)Instantiate (prefabulous, location, rotation);
    game_objects.Add(new_thing);

    new_thing.transform.localScale = scale;

    new_thing.renderer.material.SetColor("_Color", new Color(color.x, color.y, color.z));

    NetworkView new_network_view = new_thing.GetComponent<NetworkView>();
    new_network_view.viewID = view_id;
  }


  public void request_color_change(GameObject destination_object, Color color) {
    Vector3 color_vec = new Vector3(color.r, color.g, color.b);

    networkView.RPC("color_object", RPCMode.All, destination_object.GetComponent<NetworkView>().viewID, color_vec);
  }


  [RPC]
  void color_object(NetworkViewID view_id, Vector3 color, NetworkMessageInfo info) {
    foreach(GameObject game_object in game_objects) {
      NetworkView network_view = game_object.GetComponent<NetworkView>();
      if(network_view.viewID == view_id) {
        game_object.renderer.material.SetColor("_Color", new Color(color.x, color.y, color.z));
        return;
      }
    }
  }
}

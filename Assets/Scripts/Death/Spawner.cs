using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
Manages periodically respawning a group of objects
The group of objects it manages respawning is exactly its children
Said objects should deactivate themselves instead of destroying themselves
*/
public class Spawner : MonoBehaviourPun, IPunObservable
{

    //public string prefabDir = "Prefabs";
    //public GameObject spawn;
    public float respawnTime = 20;

    private List<GameObject> instances;
    private int indFirstActive; // tracks the first active game object in the list
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

        // get all children
        instances = new List<GameObject>();
        foreach(Death t in GetComponentsInChildren<Death>()){
            instances.Add(t.gameObject);

            // configure respawn style
            t.DoDeativate = true;
            t.spawnPos = t.transform.position;
        }

        indFirstActive = 0;
        timer = -100;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine) {
            if(indFirstActive >= instances.Count){ // if there are no more active children
                if(timer + respawnTime < Time.time){ // if the timer is up
                    //PhotonNetwork.Instantiate(prefabDir + "/" + spawn.name, transform.position, transform.rotation);
                    respawnAll();
                }
            }else{
                timer = Time.time;
                // advance first active
                for(; indFirstActive < instances.Count; indFirstActive++) {
                    if(instances[indFirstActive].activeInHierarchy) {
                        break;
                    }
                }
            }
        }
    }

    private void respawnAll(){
        Debug.Log("Respawning all instances from spawner");
        foreach(GameObject go in instances){
            go.SetActive(true);
        }
        indFirstActive = 0;
    }

    // sync the activation status of all children
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if(stream.IsWriting){
            foreach(GameObject go in instances){
                stream.SendNext(go.activeInHierarchy);
            }
        } else {
            foreach(GameObject go in instances){
                go.SetActive((bool)stream.ReceiveNext());
            }
        }
    }

}

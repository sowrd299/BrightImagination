using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviourPun
{

    public string prefabDir = "Prefabs";
    public GameObject spawn;
    public float respawnTime = 20;

    private GameObject instance;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = -100;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine) {
            if(!instance && spawn){
                if(timer + respawnTime < Time.time){
                    PhotonNetwork.Instantiate(prefabDir + "/" + spawn.name, transform.position, transform.rotation);
                }
            }else{
                timer = Time.time;
            }
        }
    }

}

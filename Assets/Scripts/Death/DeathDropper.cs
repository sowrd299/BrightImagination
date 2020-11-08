using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
A component for managing monsters dropping items on death
To be paired with an inventory and a death component
 */
public class DeathDropper : MonoBehaviourPun, DeathListener
{

    public string prefabDir = "Prefabs";
    // the prefab (with an inventory) to drop on death
    public GameObject itemDropPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeath(){
        if(photonView.IsMine){
            object[] data =  { 
                // testing
                new int[]{LocalPlayerManager.ViewID},
                new string[]{ "WeakJelly" }
            };
            PhotonNetwork.Instantiate(prefabDir + "/" + itemDropPrefab.name, transform.position, transform.rotation, 0, data);
        }
    }

}

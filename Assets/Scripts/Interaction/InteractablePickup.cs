using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InteractablePickup : Interactable
{

    private Inventory inventory;

    new void Start(){
        base.Start();
        inventory = GetComponent<Inventory>();
    }

    public override void Interact(GameObject player){
        //TODO: Probably shouldn't use local player for this
        Inventory to = player?.GetComponent<Inventory>();
        if(inventory && to){
            foreach(var pair in inventory.Items){
                to.Add(pair.Key, pair.Value);
            }
        }
        PhotonNetwork.Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InteractablePickup : Interactable
{

    private Inventory inventory;
    private Death death;

    new void Start(){
        base.Start();
        inventory = GetComponent<Inventory>();
        death = GetComponent<Death>();
    }

    public override void Interact(GameObject player){
        //TODO: Probably shouldn't use local player for this
        Inventory to = player?.GetComponent<Inventory>();
        if(inventory && to){
            foreach(var pair in inventory.Items){
                to.Add(pair.Key, pair.Value);
            }
        }
        destroy();
    }

    /**
    Should always handle destroying the object
    Prevents the object from being destroyed if it could be respawned
    */
    private void destroy(){
        death?.Die();
    }

}

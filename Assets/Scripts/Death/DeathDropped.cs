using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


/**
A class specifically for unpacking the messages sent by Death Droppper
To be used with a Visibility Restriction and an Inventory
*/
public class DeathDropped : MonoBehaviour, IPunInstantiateMagicCallback
{

    public string itemDir = "Items";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info) {
        object[] data = info.photonView.InstantiationData;

        // unpack visibility
        int[] visibleTo = (int[])data[0];
        GetComponent<VisibilityRestriction>().SetVisibility(visibleTo);

        // items to add to the inventory
        // this SHOULD run on all copies, because inventories aren't
        //      ...currently synced
        Inventory inventory = GetComponent<Inventory>();
        string[] items = (string[])data[1];
        foreach(string s in items){
            Item item = Resources.Load<Item>(itemDir + "/" + s) as Item;
            if(item) {
                inventory.Add(item);
            } else {
                Debug.Log("DeathDropped: Item '"+s+"' not found in items dir '"+itemDir+"'");
            }
        }

    }
}

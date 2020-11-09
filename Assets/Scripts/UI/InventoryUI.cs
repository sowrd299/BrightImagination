using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : HudUI
{

    private Inventory inventory;
    private List<GameObject> slots;

    new void Start(){
        // collect a list of slots
        slots = new List<GameObject>();
        foreach(Transform t in transform){
            if(t.tag == "InventorySlot"){
                slots.Add(t.gameObject);
            }
        }
        base.Start();
    }

    new void Update(){
        base.Update();
        if(!inventory){
            inventory = LocalPlayerManager.LocalPlayerCharacter?.GetComponent<Inventory>();
        }
    }

    new public void Display(){
        UpdateDisplay();
        base.Display();
    }

    /**
    Updates the inventory being displayed
    */
    private void UpdateDisplay(){
        int i = 0; // indexor for inventory slots
        if(inventory){
            foreach(var pair in inventory.Items){

                // show the slot
                slots[i].SetActive(true);

                // show the right text
                slots[i].GetComponentInChildren<TMP_Text>().text = pair.Key.itemName;

                // setup the listener to handle using the item
                slots[i].GetComponent<Button>().onClick.RemoveAllListeners();
                slots[i].GetComponent<Button>().onClick.AddListener(delegate{
                    pair.Key.Use(LocalPlayerManager.LocalPlayerCharacter);
                    UpdateDisplay();
                });

                // keep count of what slot we are displaying in
                i++;
                if(i >= slots.Count){
                    break;
                }
            }
        }

        // for all remaining items
        for(; i < slots.Count; i++){
            slots[i].SetActive(false);
        }
    }

}

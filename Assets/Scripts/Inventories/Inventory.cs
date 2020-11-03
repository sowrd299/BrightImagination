using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private Dictionary<Item, int> items;
    public Dictionary<Item, int> Items{
        get{
            return items;
        }
    }

    void Start(){
        items = new Dictionary<Item, int>();

        // testing
        Item startingItem = Resources.Load<EquipmentItem>("Items/KoEyeE");
        Add(startingItem);
        Item startingItem1 = Resources.Load<EquipmentItem>("Items/KoEyeO");
        Add(startingItem1);
    }

    public void Add(Item item, int count = 1){
        if(!items.ContainsKey(item)){
            items.Add(item, 0);
        }
        items[item] += count;
    }

    public void Remove(Item item, int count = 1){
        if(items.ContainsKey(item)){
            items[item] -= count;
            if(items[item] <= 0){
                items.Remove(item);
            }
        }
    }

}
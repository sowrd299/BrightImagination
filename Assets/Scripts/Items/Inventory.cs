using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item> startingItems;

    private Dictionary<Item, int> items;
    public Dictionary<Item, int> Items{
        get{
            return items;
        }
    }

    private void initItems(){
        if(items == null){
            Empty();
            foreach(Item i in startingItems){
                Add(i);
            }
        }
    }

    void Start(){
        initItems();
    }

    /**
    CAN safely be called from other starts
    Will initialize the inventory early in that case
    */
    public void Add(Item item, int count = 1){
        initItems();
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

    public void Empty() {
        items = new Dictionary<Item, int>();
    }

}
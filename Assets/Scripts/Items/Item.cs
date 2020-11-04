using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Base Item", order = 1)]
public class Item : ScriptableObject
{

    public string name;

    public virtual void Use(GameObject userPlayer) { }

    /**
    To be called when an item is used up
    */
    public void Consume(GameObject userPlayer){
        userPlayer.GetComponent<Inventory>()?.Remove(this);
    }

}

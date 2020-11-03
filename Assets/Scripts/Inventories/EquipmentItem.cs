using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A class to represent a piece of equipment in the player's inventory
*/
[CreateAssetMenu(fileName = "Eye", menuName = "ScriptableObjects/Equipment Item", order = 2)]
public class EquipmentItem : Item
{

    public string equipmentName;

    public override void Use(GameObject userPlayer){
        Debug.Log("Equiping " + name);
        userPlayer.GetComponent<EquipmentWearer>()?.Equip(equipmentName);
        Consume(userPlayer);
    }

}

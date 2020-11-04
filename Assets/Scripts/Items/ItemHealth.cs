using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Jelly", menuName = "ScriptableObjects/Health Item", order = 4)]
public class ItemHealth : Item
{

    public int health;

    public override void Use(GameObject userPlayer) {
        userPlayer.GetComponent<Death>()?.Heal(health);
        Consume(userPlayer);
    }

}

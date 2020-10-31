using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
A script for all attacks that determine their targets with a trigger collider
Actually deals the attack's damage
*/
public class ColliderAttack : MonoBehaviourPun
{

    public float damage = 15;
    public string team = "player";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {
        Death target = other.GetComponent<Death>();
        if(target){
            target.Damage(damage, team);
        }
    }


}

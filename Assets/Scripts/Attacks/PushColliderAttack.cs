using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
A version of collider attack that pushes back on the target
Adds recoin to the target
 */
public class PushColliderAttack : ColliderAttack
{

    public float pushPower = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void attack (Death target){
        base.attack(target);
        Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();
        if(targetRb){
            targetRb.AddForce( (target.transform.position - transform.position) * pushPower );
        }
    }

}

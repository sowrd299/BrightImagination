using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
A script for all mortal and damagable things
*/
public class Death : MonoBehaviourPun, IPunObservable
{

    // spawn location config
    public string spawnLocName = "SpawnLocation";
    public GameObject spawnLoc;

    // components
    new private Rigidbody2D rigidbody;
    
    // health (including config)
    public string team = "player";
    public float maxHP = 100f;
    private float hp; 
    public float HP {
        get{
            return hp;
        }
    }


    // timestamps for damage flash
    private float timeDamaged = -100;
    public float TimeDamaged{
        get{
            return timeDamaged;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spawnLoc = GameObject.Find(spawnLocName);

        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
    Always use this call when initiating new damage
    Damage will be prevented if it from the same team as this script
    */
    public void Damage(float damage, string team = ""){
        if(photonView.IsMine && team != this.team){
            this.damage(damage);
        }
    }

    /**
    Only to be used by damage or when responding to net streams
    */
    private void damage(float damage){
        hp -= damage;
        if(hp < 0){
            hp = maxHP;
            Die();
        }

        // log time damaged
        timeDamaged = Time.time;
    }

    /**
     To be called when the player dies
     Handles killing and respawning the player
     */
    public void Die(){
        transform.position = spawnLoc.transform.position;
        rigidbody.velocity = Vector3.zero;
    }


    // syncing health values over Photon
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if(stream.IsWriting){
            stream.SendNext(hp);
        }else{
            // catchup on damage
            float hp = (float)stream.ReceiveNext();
            if(hp != this.hp){
                damage(this.hp - hp);
            }
        }
    }

}

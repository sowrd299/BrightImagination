using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
A script for all mortal and damagable things
*/
// TODO: Maybe break this into multiple scripts?
public class Death : MonoBehaviourPun, IPunObservable
{

    // spawn location config
    public string spawnLocName = "";
    public Vector3? spawnPos;

    // setting this to true will force the object to die by deactiving itself
    // the object will wait to be reactivated by another script
    private bool doDeactivate = false;
    public bool DoDeativate{
        set{
            doDeactivate = value;
        }
    }


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
        spawnPos = GameObject.Find(spawnLocName)?.transform.position;

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
     To be called when the object dies
     Handles killing the player
     Will also handles respawing IF that is configured
     */
    public void Die(){
        photonView.RPC("_die", RpcTarget.All);
    }

    // to only ever be called by Die, so that all game copies agree
    [PunRPC]
    private void _die(PhotonMessageInfo info){

        bool respawning = false;

        if(doDeactivate){
            gameObject.SetActive(false);
            respawning = true;
        }
        
        if(spawnPos != null){
            transform.position = (Vector3)spawnPos;
            rigidbody.velocity = Vector3.zero;
            respawning = true;
        }

        if(!respawning){
            PhotonNetwork.Destroy(gameObject);
        }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
 A script that should go on all attack objects
 Handles logging and such
 Also handles matching the basic transform properties of the player
 */
public class AttackController : MonoBehaviourPun
{

    public Vector3 offset = new Vector3(0, 0, -1);

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // child this to the player who spawned it
        if(photonView.IsMine){
            /*
            Debug.Log(LocalPlayerManager.LocalPlayerCharacter);
            transform.SetParent(LocalPlayerManager.LocalPlayerCharacter.transform);
            */
            player = LocalPlayerManager.LocalPlayerCharacter.transform;
            PlayerController pc = player.GetComponent<PlayerController>();
            pc.CurrentAttack = gameObject;

            // face in the same direction as the player
            if(pc.Facing < 0){
                transform.Rotate(0, 180, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // FOLLOW THE PLAYER
        if(player){
            transform.position = player.position + offset;
        }
    }
}

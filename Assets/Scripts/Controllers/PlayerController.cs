﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MovementController
{

    // MOVEMENT ADJUSTMENTS
    public float jumpPower = 400;
    public float dragFactor = 0.9f;


    // COMBAT ADJUSTMENTS
    public string attackDir = "Prefabs/Attacks";
    public GameObject mainAttack;


    // COMPONENTS
    private Rigidbody2D rigidBody;
    private Interactor interactor;


    // ACTION STATES
    private GameObject currentAttack;
    public GameObject CurrentAttack {
        set{
            currentAttack = value;
        }
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        rigidBody = GetComponent<Rigidbody2D>();
        interactor = GetComponentInChildren<Interactor>();

        facing = 0;

        // TESTING
        mainAttack = Resources.Load<GameObject>("Prefabs/Attacks/Mace") as GameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // PREVENT PLAYERS FROM CONTROLLING OTHER PEOPLE'S AVATARS
        if (photonView.IsMine || !PhotonNetwork.IsConnected) {

            // IF THE PLAYER IS ON THE GROUND...
            RaycastHit2D hit = groundCheck(0);
            if(hit.collider) {
                
                // LATERAL MOVEMENT
                rigidBody.AddForce(speed * transform.right * Input.GetAxis("Horizontal"));

                // update facing to reflect movement; prevent it from being 0
                if(Input.GetButton("Horizontal")){
                    facing = (int)Input.GetAxis("Horizontal");
                }

                // DRAG
                if(!Input.GetButton("Horizontal")) {
                    rigidBody.AddForce( new Vector3(-dragFactor * rigidBody.velocity.x, 0, 0) ); // drag force
                }

                // JUMPING
                if(Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0) {
                    rigidBody.AddForce( jumpPower * transform.up );
                }

                // INTERACT
                if(Input.GetButtonDown("Interact")) {
                    if(!interactor) {
                        interactor = GetComponentInChildren<Interactor>();
                    }
                    interactor.Target?.Interact(gameObject);
                }

                // ACTIVATE MAIN ATTACK
                if(!currentAttack && Input.GetButtonDown("MainFire")){
                    PhotonNetwork.Instantiate(attackDir + "/" + mainAttack.name, transform.position, transform.rotation, 0);
                }

            }


            // CAN FORCE RESPAWN IF YOU GET STUCK :(
            if(Input.GetButtonDown("Respawn")){
                death.Die();
            }

        }
        
    }
}

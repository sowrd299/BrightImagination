using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{

    // MOVEMENT ADJUSTMENTS
    public LayerMask UseForJump;
    public float speed = 10;
    public float jumpPower = 800;
    public float dragFactor = 0.9f;
    public float minY = -40;

    // COMPONENTS
    private Rigidbody2D rigidBody;
    private Death death;
    private Interactor interactor;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        death = GetComponent<Death>();
        interactor = GetComponentInChildren<Interactor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // FAIL SALE FOR FALLING OFF THE WORLD
        if(transform.position.y < minY){
            death.Die();
        }

        // PREVENT PLAYERS FROM CONTROLLING OTHER PEOPLE'S AVATARS
        if (photonView.IsMine || !PhotonNetwork.IsConnected) {

            // IF THE PLAYER IS ON THE GROUND...
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.6f, UseForJump);
            if(hit.collider) {
                
                // LATERAL MOVEMENT
                rigidBody.AddForce(speed * transform.right * Input.GetAxis("Horizontal"));

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

            }

            if(Input.GetButtonDown("Respawn")){
                death.Die();
            }

        }
        
    }
}

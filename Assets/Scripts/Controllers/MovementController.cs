using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/** 
An abstract base class for controlling things that move
*/
public abstract class MovementController : MonoBehaviourPun, IPunObservable
{

    public LayerMask groundLayer;
    public float speed = 5;


    // tracks the direction the Mover is TRAVELING
    private Vector3 _dir;
    protected Vector3 dir{
        get{
            return _dir != null ? _dir : transform.right * facing;
        }
        set{
            _dir = value;
        }
    }

    // Tracks the direction the Move is FACING
    // -1 for left, 0 for forward, 1 for right
    protected int facing;
    public int Facing{
        get{
            return facing;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected RaycastHit2D groundCheck(float lookAheadDist){
        RaycastHit2D hit = Physics2D.Raycast(transform.position + dir * lookAheadDist, -transform.up, 0.6f, groundLayer);
        return hit;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if(stream.IsWriting){
            stream.SendNext(facing);
        }else{
            // catchup on damage
            facing = (int)stream.ReceiveNext();
        }
    }
}

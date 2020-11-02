using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Merge this with player controller?
public class MonsterController : MovementController
{

    public float lookAheadDist = 2;

    new private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
        rigidbody = GetComponent<Rigidbody2D>();

        facing = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(dir * speed);

        // turn around when appropriate
        RaycastHit2D aheadHit = groundCheck(lookAheadDist);
        if(!aheadHit){
            dir *= -1;
            facing *= -1;
        }

        // hard stop at edge
        RaycastHit2D edgeHit = groundCheck(1f);
        RaycastHit2D groundHit = groundCheck(0f);
        if(!edgeHit  && groundHit){
            rigidbody.velocity = Vector3.zero;
        }
    }
}

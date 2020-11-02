using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Merge this with player controller?
public class MonsterController : MonoBehaviour
{

    public LayerMask groundLayer;
    public float speed = 5;
    public float lookAheadDist = 2;

    private Vector3 dir;

    new private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private RaycastHit2D groundCheck(float lookAheadDist){
        RaycastHit2D hit = Physics2D.Raycast(transform.position + dir * lookAheadDist, -transform.up, 0.6f, groundLayer);
        return hit;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(dir * speed);

        // turn around when appropriate
        RaycastHit2D aheadHit = groundCheck(lookAheadDist);
        if(!aheadHit){
            dir *= -1;
        }

        // hard stop at edge
        RaycastHit2D edgeHit = groundCheck(1f);
        RaycastHit2D groundHit = groundCheck(0f);
        if(!edgeHit  && groundHit){
            rigidbody.velocity = Vector3.zero;
        }
    }
}

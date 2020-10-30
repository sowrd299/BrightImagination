using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position + dir * lookAheadDist, -transform.up, 0.6f);
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
        if(!edgeHit){
            rigidbody.velocity = Vector3.zero;
        }
    }
}

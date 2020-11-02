using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
To be put on all equipment
*/
public class EquipmentController : MonoBehaviour
{

    // TODO: Use a generalized controller that supports monsters and NPC's
    private PlayerController playerController;

    private int oldFacing;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        oldFacing = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController){
            // face the correct direction
            // do so by flipping 180 whenever facing exact opposit of directin currently facing
            if(oldFacing == -1 * playerController.Facing) {
                transform.Rotate(0, 180, 0);
                oldFacing = playerController.Facing;
            }
        }
    }
}

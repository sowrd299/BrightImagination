using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Page", menuName = "ScriptableObjects/Readable Item", order = 3)]
public class ItemReadable : Item
{

    // TODO: merge all this copy-pasted cost with Dialog, probably through a Scriptable Object
    //      ... or maybe static methods?
    [TextArea(3,10)]
    public string text = "This a page from a book....";
    public string canvasName = "Canvas";

    private DialogUI dialogUI;

    public override void Use(GameObject userPlayer) {
        if(!dialogUI){
            dialogUI = GameObject.Find(canvasName).GetComponent<HudController>().Dialog;
        }
        base.Use(userPlayer);
        dialogUI.Display(text);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : HudUI
{

    /**
    To be called to display text
     */
    public void Display(string dialog) {
        transform.Find("Text").GetComponent<TMP_Text>().text = dialog;
        base.Display();
    }

}

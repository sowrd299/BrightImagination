using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public abstract class Interactable : MonoBehaviourPun
{

    public string text = "!";
    public string highlightText = "Talk!";

    private TMP_Text tmp;

    // Start is called before the first frame update
    protected void Start()
    {
        tmp = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }


    public abstract void Interact(GameObject player);

    // CHANGE APPEARANCE IF BEING LIGHTED
    public void Highlight() {
        tmp.text = highlightText;
    }

    public void Unhighlight() {
        tmp.text = text;
    }

}

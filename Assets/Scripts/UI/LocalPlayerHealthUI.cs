using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
To be put on a TMPro object to make that object display the local player's health
*/
public class LocalPlayerHealthUI : MonoBehaviour
{

    public string hpText = "HP";

    private TMP_Text tmp;
    private Death death;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

        // always correct if local player is missing
        // this also compensates for when starts happen out of order
        if(!death && LocalPlayerManager.LocalPlayerCharacter){
            death = LocalPlayerManager.LocalPlayerCharacter.GetComponent<Death>(); 
        }

        tmp.text = death?.HP.ToString() + hpText;
    }
}

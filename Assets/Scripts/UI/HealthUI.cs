using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
A script to go on a TextMesh Pro object that is childed to a mortal
Will make that TMP display display the mortal's health
    whenever it takes damage
*/
public class HealthUI : MonoBehaviour
{

    public float dispTime = 2f;
    public string hpText = "HP";

    private TMP_Text tmp;
    private Death death;

    private bool displayingHP;
    private string oldText;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMP_Text>();
        death = GetComponentInParent<Death>();
        displayingHP = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(death.TimeDamaged + dispTime > Time.time){
            if(!displayingHP){
                displayingHP = true;
                oldText = tmp.text;
            }
            tmp.text = death.HP.ToString() + hpText;
        }else if(displayingHP){
            displayingHP = false;
            tmp.text = oldText;
        }
    }
}

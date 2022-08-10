using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Three_Health : SC_HealthBar
{

    public SpriteRenderer heart_1;
    public SpriteRenderer heart_2;
    public SpriteRenderer heart_3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void updateHealthBar()
    {
        float current = health.GetCurrentHP();

        if(current <= 2.0F){
            heart_3.enabled = false;
        }

        if(current <= 1.0F){
            heart_2.enabled = false;
        }

        if(current <= 0.0F){
            heart_1.enabled = false;
        }
    }
}

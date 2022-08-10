using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_One_Health : SC_HealthBar
{
    public SpriteRenderer heart_1;


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
        if(current <= 0.0F){
            heart_1.enabled = false;
        }
    }
}

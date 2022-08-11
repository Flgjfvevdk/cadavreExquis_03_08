using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ennemiStun : MonoBehaviour
{
    public Behaviour scriptToUnactiveIfStun;
    public float tempsMax_stun;
    private float tempsRestant_stun;

    void Update()
    {
        if(tempsRestant_stun > 0)
        {
            tempsRestant_stun -= Time.deltaTime;
        } else if (!scriptToUnactiveIfStun.enabled)
        {
            scriptToUnactiveIfStun.enabled = true;
        }
    }
    public void unactive()
    {
        scriptToUnactiveIfStun.enabled = false;
        tempsRestant_stun = tempsMax_stun;
    }
}

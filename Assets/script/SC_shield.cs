using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_shield : MonoBehaviour
{


    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
         // get the heath script in the parent
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(gameObject.transform.parent.GetComponent<SC_player>().isShield)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

}

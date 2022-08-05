using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {   /*
        if(gameObject.GetComponentInParent().shield == 1)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        */
    }
}

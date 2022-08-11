using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_prespawn : MonoBehaviour
{
    public GameObject obj;
    public float delaieSpawn;
    public float temps_disparition;// temps de disparition après avoir fait spawn l'objet
    public float sizeMax;
    private float t;
    private bool alreadySpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (!alreadySpawn)
        {
            if (t >= delaieSpawn)
            {
                t = 0;
                Instantiate(obj, transform.position, Quaternion.identity);
                alreadySpawn = true;
            } else
            {
                transform.localScale = Vector3.one * sizeMax * t / delaieSpawn;
            }
        } else
        {
            if (t >= temps_disparition)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.localScale = Vector3.one * sizeMax * (temps_disparition - t) / temps_disparition;
            }
        }
    }
}

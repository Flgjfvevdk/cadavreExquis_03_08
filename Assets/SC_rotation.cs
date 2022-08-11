using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_rotation : MonoBehaviour
{
    public float speed;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, speed * t);
    }
}

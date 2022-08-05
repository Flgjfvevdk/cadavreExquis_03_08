using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_camera : MonoBehaviour
{

    public float shake;
    public float shakeAmount;
    public float decreaseFactor;
    // Start is called before the first frame update
    void Start()
    {
        shake = 0.0f;
        shakeAmount = 0.7f;
        decreaseFactor = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shake > 0.0f) {
            gameObject.transform.localPosition = Random.insideUnitSphere * shakeAmount + new Vector3(0,0,-10);
            shake -= Time.deltaTime * decreaseFactor;
        } else {
            shake = 0.0f;
            gameObject.transform.localPosition = new Vector3(0,0,-10);
        }
    }
}

    

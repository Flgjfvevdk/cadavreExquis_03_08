using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_petiteParticule : MonoBehaviour
{
    public float tempsDeVieMax;
    private float t;
    public float size_debut;
    public float size_fin;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if( t >= tempsDeVieMax)
        {
            Destroy(gameObject);
        }
        float size = size_fin * (t / tempsDeVieMax) + size_debut * ((tempsDeVieMax - t) / tempsDeVieMax);
        transform.localScale = size * Vector3.one;
    }
}

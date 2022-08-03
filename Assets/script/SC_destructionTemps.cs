using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Ce script est � plac� dans tous les gameobject qu'on souhaite voir automatiquement disparaitre au bout d'un certains temps de vie
/// Cela permet par exemple (sans trop se prendre la t�te) d'�viter que trop de gameobject restent sur la scene

public class SC_destructionTemps : MonoBehaviour
{
    public float tempsDeVie;

    // Update is called once per frame
    void Update()
    {
        tempsDeVie -= Time.deltaTime;
        if(tempsDeVie <= 0)
        {
            Destroy(gameObject);
        }
    }
}

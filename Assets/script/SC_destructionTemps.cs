using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Ce script est à placé dans tous les gameobject qu'on souhaite voir automatiquement disparaitre au bout d'un certains temps de vie
/// Cela permet par exemple (sans trop se prendre la tête) d'éviter que trop de gameobject restent sur la scene

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

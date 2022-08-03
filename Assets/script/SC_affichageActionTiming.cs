using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_affichageActionTiming : MonoBehaviour
{
    public GameObject cercleJaune;
    public float maxSize;
    public float pourcentageRemplissage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cercleJaune.transform.localScale = pourcentageRemplissage * maxSize * Vector3.one;
    }

}

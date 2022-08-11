using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SC_affichageScoreFin : MonoBehaviour
{
    [System.NonSerialized]
    public static int score;

    public TextMeshProUGUI textPro;
    // Start is called before the first frame update
    void Start()
    {
        textPro.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SC_shieldAmmo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI remaining;
    // Start is called before the first frame update
    void Start()
    {
        remaining.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRemaining(int qty)
    {
        this.remaining.text = qty.ToString();
    }
}

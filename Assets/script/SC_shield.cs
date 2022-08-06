using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_shield : MonoBehaviour
{
    // pour le bouclier
    public float tempsbouclier_max;
    private float tempsbouclier_restant;
    [SerializeField]
    private ItemImage shieldImage;
    [SerializeField]
    private SC_health health;


    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        // get the heath script in the parent
    }

    // Update is called once per frame
    void Update()
    {
        // TODO Voltini : pas fan de la recherche de statut de shield, au lieu de tester a chaque
        // frame il suffit de declencher une fonction quand le temps restant du shield arrive a 0
        Debug.Log("temps restant" + tempsbouclier_restant);
        if (tempsbouclier_restant > 0)
        {
            tempsbouclier_restant -= Time.deltaTime;
            //Debug.Log(gameObject.name + " a un bouclier");
            Debug.Log("temps restant" + tempsbouclier_restant);
            if (!this.IsShielded())
            {
                this.updateShieldState(false);
                shieldImage.updateSprite(false);
            }
        }
    }

    public void updateShieldState(bool playerIsShielded)
    {
        GetComponent<SpriteRenderer>().enabled = playerIsShielded;
        health.cantBeDamaged = playerIsShielded;
    }

    public void getShield()
    {
        tempsbouclier_restant = tempsbouclier_max;
        this.updateShieldState(true);
        shieldImage.updateSprite(true);
    }

    public bool IsShielded()
    {
        return tempsbouclier_restant > 0;
    }

}

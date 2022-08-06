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

    }

    public void updateShieldState(bool playerIsShielded)
    {
        GetComponent<SpriteRenderer>().enabled = playerIsShielded;
        health.cantBeDamaged = playerIsShielded;
    }

    public void getShield()
    {
        this.updateShieldState(true);
        shieldImage.updateSprite(true);
        StartCoroutine(DisableShieldAfter(tempsbouclier_max));
    }

    IEnumerator DisableShieldAfter(float time)
    {
        yield return new WaitForSeconds(time);
        this.updateShieldState(false);
        shieldImage.updateSprite(false);
    }

    public bool IsShielded()
    {
        return GetComponent<SpriteRenderer>().enabled;
    }

}

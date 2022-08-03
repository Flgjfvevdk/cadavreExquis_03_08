using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_health : MonoBehaviour
{
    public float max_hp;
    private float current_hp;

    public bool isPlayer;

    public float tempsInvicibilite_max;
    private float tempsInvicibilite_restant;

    public bool cantBeDamaged; //Faux = peut se prendre des dégâts

    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;
    }

    private void Update()
    {
        if(tempsInvicibilite_restant >= 0)
        {
            tempsInvicibilite_restant -= Time.deltaTime;

        }
    }

    public void getHit(float damage = 1) //On surchage getHit
    {
        // Si cantBeDamaged est vrai, alors on annule le getHit
        if (cantBeDamaged || tempsInvicibilite_restant > 0)
        {
            return;
        }

        //On diminue les pj d'autant que nécessaire
        current_hp -= damage;

        //On rend invicible le gameobject (si tempsInvicibilite_max = 0, il se deviendra pas invincible)
        tempsInvicibilite_restant = tempsInvicibilite_max;

        if (current_hp <= 0)
        {
            if (isPlayer)
            {
                diePlayer();
            } else
            {
                dieEnnemy();
            }
        }
    }

    private void dieEnnemy()
    {
        //On peut rajouter un effet à la mort ou autre ici
        Destroy(gameObject);
    }

    private void diePlayer()
    {
        // Juste un truc provisoire à changer
        Debug.LogWarning("Faudra changer, pour l'instant on reload juste la scene quand le pj meurt");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool isInvincible()
    {
        return tempsInvicibilite_restant > 0;
    }


}

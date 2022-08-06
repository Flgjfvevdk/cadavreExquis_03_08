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

    public bool cantBeDamaged; //Faux = peut se prendre des d�g�ts
    // pour la barre de vie
    [SerializeField]
    private SC_HealthBar healthBar;

    [SerializeField]
    private SC_score score;

    // Start is called before the first frame update
    void Start()
    {
        current_hp = max_hp;
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<SC_score>();
    }

    private void Update()
    {
        if (tempsInvicibilite_restant > 0)
        {
            tempsInvicibilite_restant -= Time.deltaTime;
            //Debug.Log(gameObject.name + " est provisoirement invincible");
        }
    }

    public void getLife()
    {
        if (current_hp < max_hp)
        {
            current_hp += 1;
            this.healthBar.updateHealthBar();
        }
    }



    public void getHit(float damage = 1) //On surchage getHit
    {
        // Si cantBeDamaged est vrai, alors on annule le getHit
        if (cantBeDamaged || tempsInvicibilite_restant > 0)
        {
            return;
        }

        //On diminue les pj d'autant que n�cessaire
        current_hp -= damage;
        this.healthBar.updateHealthBar();

        //On rend invicible le gameobject (si tempsInvicibilite_max = 0, il se deviendra pas invincible)
        tempsInvicibilite_restant = tempsInvicibilite_max;

        if (current_hp <= 0)
        {
            if (isPlayer)
            {
                diePlayer();
            }
            else
            {
                dieEnnemy();
            }
        }
    }

    public float GetCurrentHP()
    {
        return this.current_hp;
    }

    private void dieEnnemy()
    {
        //On peut rajouter un effet � la mort ou autre ici
        score.score += Mathf.FloorToInt(100 * max_hp);
        Destroy(gameObject);
    }

    private void diePlayer()
    {
        // Juste un truc provisoire � changer
        Debug.LogWarning("Faudra changer, pour l'instant on reload juste la scene quand le pj meurt");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool isInvincible()
    {
        return tempsInvicibilite_restant > 0;
    }
}

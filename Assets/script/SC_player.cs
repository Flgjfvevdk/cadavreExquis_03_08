using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ne pas oublier d'importer �a pour utiliser le new input systeme _______________________________________________________________
using UnityEngine.InputSystem; 

public class SC_player : MonoBehaviour
{
    // Variables pour les d�g�ts et les pv _______________
    private SC_health healthScript;
    // ___________________________________________________

    // Variables pour le d�placement ________
    public float speed;
    private Rigidbody2D rb;
    // ______________________________________

    // variables pour le tir ____________________________
    public GameObject balle_prefab; // prefab de l'objet instanti� avec l'action 1, cela peut �tre n'importe quoi.
    public float vitesseProjectile;
    public float delaieMax_tir;
    private float delaieRestant_tir;
    // ____________________________________________________

    // Variables pour le dash ____________________________
    public float dureeDash; // Le temps que met le dash 
    public float vitesseDash; // vitesse du dash
    private bool isDashing;
    private Vector2 directionDash; // Si isDashing est vrai, cette variable enregistre la position qu'aura le joueur � la fin du dash
    public float delaieMax_dash;
    private float delaieRestant_dash;
    private float t_dash;

    public float opacitePendantDash;
    public GameObject petiteParticule;
    private float delaieMax_spawnPetiteParticule = 0.01f;
    private float delaieRestant_spawnPetiteParticule;
    // ____________________________________________________

    // Variables pour le shield ____________________________
    public int shield;
    public bool isShield;

    // Variables relatifs au input ___________________
    private Vector2 directionInput; //R�cup�re les touches d'input entr�es par le joueurs � travers un vector norm�
    private bool action_1_Input_isPressed; //Pour voir quel touche est lieu � �a, aller voir gestionnaireControlJeu (pas le script)
    private bool action_2_Input_isPressed; //Pour voir quel touche est lieu � �a, aller voir gestionnaireControlJeu (pas le script)
    private bool action_3_Input_isPressed; //Pour voir quel touche est lieu � �a, aller voir gestionnaireControlJeu (pas le script)
    private bool action_4_Input_isPressed; //Pour voir quel touche est lieu � �a, aller voir gestionnaireControlJeu (pas le script)
    private bool action_5_Input_isPressed; //Pour voir quel touche est lieu � �a, aller voir gestionnaireControlJeu (pas le script)
    // ____________________________________________________

    // Awake est appel� quand l'instance du script est charg� (et donc avant les �ventuelles start)
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //on r�cup�re la composante rigidbody2D du gameobject attach� � ce script
        healthScript = GetComponent<SC_health>(); //on r�cup�re une r�f�rence au script de pv
        shield = 0;
        isShield = false;
    }

    // Update is called once per frame
    void Update()
    {
        miseAJour_variablesTemporelles();

        // On g�re le dash (action2)
        if (isDashing)
        {
            if(t_dash < dureeDash)
            {
                rb.velocity = vitesseDash * directionDash.normalized;
                t_dash += Time.deltaTime;

                //On fait le spawn de petite particule
                if(delaieRestant_spawnPetiteParticule <= 0)
                {
                    Instantiate(petiteParticule, transform.position, Quaternion.identity);
                    delaieRestant_spawnPetiteParticule = delaieMax_spawnPetiteParticule;
                } else
                {
                    delaieRestant_spawnPetiteParticule -= Time.deltaTime;
                }

                return; //En mettant ce return ici, cela permet d'emp�cher de tirer et de se d�placer pendant le dash. (c'est important de pas pouvoir se d�placer pdt le dash vu la fa�on dont est cod� le dash
            }else
            {
                isDashing = false;
                healthScript.cantBeDamaged = false;

                //on s'occupe de changer l'opacit� pour la remettre � 1
                Color ancienneCouleur = GetComponent<SpriteRenderer>().color;//On enregistre la couleur qu'on a donn� au joueur pour pas lui changer.
                GetComponent<SpriteRenderer>().color = new Color(ancienneCouleur.r, ancienneCouleur.g, ancienneCouleur.b, 1);
                
                delaieRestant_dash = delaieMax_dash; //On commence la recup de delaie du dash seulement � la fin de celui ci
            }
        }

        //On d�place le joueur si n�cessaire en jouant sur sa vitesse avec l'option slow
        if (action_5_Input_isPressed) {
            rb.velocity = speed * directionInput/2;
        } else {
            rb.velocity = speed * directionInput;
        }

        //Le joueur effectue l'action 1 si voulue
        if (action_1_Input_isPressed && delaieRestant_tir <= 0)
        {
            // On fait spawn un gameobject, � la position transform.position (c�d � la m�me position que le player) Et avec une rotation null.
            // spawnedObject fait r�f�rence fait r�f�rence � l'objet instanti�, tandis que spawnedObject_action1 fait r�f�rence au
            // prefab (un objet abstrait qui n'est pas dans la scene).
            GameObject projectile = Instantiate(balle_prefab, transform.position, Quaternion.identity);
            delaieRestant_tir = delaieMax_tir;

            //On r�cup�re la position de la souris dans l'espace
            Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 directionTir = positionSouris - transform.position;

            //!\\ Ici je sais que j'instantie un prefab qui poss�de le script SC_balle. Si le prefab ou le script accroch� � ce prefab change,
            //alors il faut adapter la ligne en dessous en cons�quence //!\\
            projectile.GetComponent<SC_balle>().allerVers(directionTir, vitesseProjectile); // On r�cup�re le script de l'objet instanti� et on ex�cute un script � distance
            projectile.GetComponent<SC_balle>().isFromPlayer = true;
        }

        //Le joueur effectue l'action 2 si voulue /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (action_2_Input_isPressed && delaieRestant_dash <= 0)
        {
            //On met la variable � true
            isDashing = true;
            t_dash = 0;

            healthScript.cantBeDamaged = true;

            //On sauvegarde la direction ou pointe la souris
            Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            directionDash = (positionSouris - transform.position).normalized;

            //on s'occupe de changer l'opacit�
            Color ancienneCouleur = GetComponent<SpriteRenderer>().color; //On enregistre la couleur qu'on a donn� au joueur pour pas lui changer.
            GetComponent<SpriteRenderer>().color = new Color(ancienneCouleur.r, ancienneCouleur.g, ancienneCouleur.b, opacitePendantDash); //On garde tout sauf l'opacite qui est modifi�e.
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // on gère les actions possibles avec le bouclier
        if (action_3_Input_isPressed && shield > 0){ // en utilisant 1 "bouclier" le joueur peut se shield
            shield -= 1;
            healthScript.getShield();
        }
        if (action_4_Input_isPressed && shield >= 3){ // en utilisant 3 "bouclier" le joueur peut détruire tout les projectiles présents
            shield -= 3;
            foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                bullet.GetComponent<SC_camera>().shake = 10.0f;
            }
            foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Projectile"))
            {
                Destroy(bullet);
            }
        }
        isShield = healthScript.IsShielded();

        

    }

    private void miseAJour_variablesTemporelles()
    {
        if(delaieRestant_tir >= 0)
        {
            delaieRestant_tir -= Time.deltaTime;
        }
        if (delaieRestant_dash >= 0)
        {
            delaieRestant_dash -= Time.deltaTime;
        }
    }

    // fonctions de gestion du shield
     public void addShield()
    {
        shield += 1;
    }

    // fonctions de detection et mise � jour et input //////////////////////////////////////////////////////////////////
    public void maj_directionInput(InputAction.CallbackContext ctx)
    {
        directionInput = ctx.ReadValue<Vector2>();
    }

    public void maj_action_1_Input(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //On est l� quand le joueur appuie sur la touche
            action_1_Input_isPressed = true;
        }
        else if (ctx.canceled)
        {
            //On est l� quand le joueur vient de relacher la touche
            action_1_Input_isPressed = false;
        }
    }

    public void maj_action_2_Input(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //On est l� quand le joueur appuie sur la touche
            action_2_Input_isPressed = true;
        }
        else if (ctx.canceled)
        {
            //On est l� quand le joueur vient de relacher la touche
            action_2_Input_isPressed = false;
        }
    }


    public void maj_action_3_Input(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //On est l� quand le joueur appuie sur la touche
            action_3_Input_isPressed = true;
        }
        else if (ctx.canceled)
        {
            //On est l� quand le joueur vient de relacher la touche
            action_3_Input_isPressed = false;
        }
    }
   
   public void maj_action_4_Input(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //On est l� quand le joueur appuie sur la touche
            action_4_Input_isPressed = true;
        }
        else if (ctx.canceled)
        {
            //On est l� quand le joueur vient de relacher la touche
            action_4_Input_isPressed = false;
        }
    }

    public void maj_action_5_Input(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //On est l� quand le joueur appuie sur la touche
            action_5_Input_isPressed = true;
        }
        else if (ctx.canceled)
        {
            //On est l� quand le joueur vient de relacher la touche
            action_5_Input_isPressed = false;
        }
    }

    // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

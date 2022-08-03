using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ne pas oublier d'importer ça pour utiliser le new input systeme _______________________________________________________________
using UnityEngine.InputSystem; 

public class SC_player : MonoBehaviour
{
    // Variables pour les dégâts et les pv _______________
    private SC_health healthScript;
    // ___________________________________________________

    // Variables pour le déplacement ________
    public float speed;
    private Rigidbody2D rb;
    // ______________________________________

    // variables pour le tir ____________________________
    public GameObject balle_prefab; // prefab de l'objet instantié avec l'action 1, cela peut être n'importe quoi.
    public float vitesseProjectile;
    public float delaieMax_tir;
    private float delaieRestant_tir;
    // ____________________________________________________

    // Variables pour le dash ____________________________
    public float dureeDash; // Le temps que met le dash 
    public float vitesseDash; // vitesse du dash
    private bool isDashing;
    private Vector2 directionDash; // Si isDashing est vrai, cette variable enregistre la position qu'aura le joueur à la fin du dash
    public float delaieMax_dash;
    private float delaieRestant_dash;
    private float t_dash;

    public float opacitePendantDash;
    public GameObject petiteParticule;
    private float delaieMax_spawnPetiteParticule = 0.01f;
    private float delaieRestant_spawnPetiteParticule;
    // ____________________________________________________

    // Variables relatifs au input ___________________
    private Vector2 directionInput; //Récupère les touches d'input entrées par le joueurs à travers un vector normé
    private bool action_1_Input_isPressed;
    private bool action_2_Input_isPressed;
    // _______________________________________________


    // Awake est appelé quand l'instance du script est chargé (et donc avant les éventuelles start)
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //on récupère la composante rigidbody2D du gameobject attaché à ce script
        healthScript = GetComponent<SC_health>(); //on récupère une référence au script de pv
    }

    // Update is called once per frame
    void Update()
    {
        miseAJour_variablesTemporelles();

        // On gère le dash (action2)
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

                return; //En mettant ce return ici, cela permet d'empêcher de tirer et de se déplacer pendant le dash. (c'est important de pas pouvoir se déplacer pdt le dash vu la façon dont est codé le dash
            }else
            {
                isDashing = false;
                healthScript.cantBeDamaged = false;

                //on s'occupe de changer l'opacité pour la remettre à 1
                Color ancienneCouleur = GetComponent<SpriteRenderer>().color;//On enregistre la couleur qu'on a donné au joueur pour pas lui changer.
                GetComponent<SpriteRenderer>().color = new Color(ancienneCouleur.r, ancienneCouleur.g, ancienneCouleur.b, 1);
                
                delaieRestant_dash = delaieMax_dash; //On commence la recup de delaie du dash seulement à la fin de celui ci
            }
        }

        //On déplace le joueur si nécessaire en jouant sur sa vitesse.
        rb.velocity = speed * directionInput;

        //Le joueur effectue l'action 1 si voulue
        if (action_1_Input_isPressed && delaieRestant_tir <= 0)
        {
            // On fait spawn un gameobject, à la position transform.position (càd à la même position que le player) Et avec une rotation null.
            // spawnedObject fait référence fait référence à l'objet instantié, tandis que spawnedObject_action1 fait référence au
            // prefab (un objet abstrait qui n'est pas dans la scene).
            GameObject projectile = Instantiate(balle_prefab, transform.position, Quaternion.identity);
            delaieRestant_tir = delaieMax_tir;

            //On récupère la position de la souris dans l'espace
            Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 directionTir = positionSouris - transform.position;

            //!\\ Ici je sais que j'instantie un prefab qui possède le script SC_balle. Si le prefab ou le script accroché à ce prefab change,
            //alors il faut adapter la ligne en dessous en conséquence //!\\
            projectile.GetComponent<SC_balle>().allerVers(directionTir, vitesseProjectile); // On récupère le script de l'objet instantié et on exécute un script à distance
            projectile.GetComponent<SC_balle>().isFromPlayer = true;
        }

        //Le joueur effectue l'action 2 si voulue /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (action_2_Input_isPressed && delaieRestant_dash <= 0)
        {
            //On met la variable à true
            isDashing = true;
            t_dash = 0;

            healthScript.cantBeDamaged = true;

            //On sauvegarde la direction ou pointe la souris
            Vector3 positionSouris = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            directionDash = (positionSouris - transform.position).normalized;

            //on s'occupe de changer l'opacité
            Color ancienneCouleur = GetComponent<SpriteRenderer>().color; //On enregistre la couleur qu'on a donné au joueur pour pas lui changer.
            GetComponent<SpriteRenderer>().color = new Color(ancienneCouleur.r, ancienneCouleur.g, ancienneCouleur.b, opacitePendantDash); //On garde tout sauf l'opacite qui est modifiée.
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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


    // fonctions de detection et mise à jour et input //////////////////////////////////////////////////////////////////
    public void maj_directionInput(InputAction.CallbackContext ctx)
    {
        directionInput = ctx.ReadValue<Vector2>();
    }

    public void maj_action_1_Input(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //On est là quand le joueur appuie sur la touche
            action_1_Input_isPressed = true;
        }
        else if (ctx.canceled)
        {
            //On est là quand le joueur vient de relacher la touche
            action_1_Input_isPressed = false;
        }
    }

    public void maj_action_2_Input(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //On est là quand le joueur appuie sur la touche
            action_2_Input_isPressed = true;
        }
        else if (ctx.canceled)
        {
            //On est là quand le joueur vient de relacher la touche
            action_2_Input_isPressed = false;
        }
    }
    // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

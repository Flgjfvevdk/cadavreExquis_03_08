using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SC_menuNavigation : MonoBehaviour
{
    public void enterKey(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //On est l? quand le joueur appuie sur la touche

            SceneManager.LoadScene("sceneJeu");
        }
    }
}

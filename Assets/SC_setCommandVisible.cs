using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SC_setCommandVisible : MonoBehaviour
{
    


    public Image imageControl;

    
    
    void Start()
    {   
        imageControl = GetComponent<Image>();
        imageControl.enabled = false;
    }


    public void enterKey(InputAction.CallbackContext ctx)
    {

        if (ctx.performed)
        {
            //On est l? quand le joueur appuie sur la touche

            imageControl.enabled = true;
        }
    }
    
}

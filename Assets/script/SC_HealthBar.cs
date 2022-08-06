using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SC_HealthBar : MonoBehaviour
{
    // cette syntax permet de modifier l'objet dans l'UI de Unity tout en le gardant private
    [SerializeField]
    private SC_player player;
    [SerializeField]
    private Image healthBarImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHealthBar()
    {
        float current = player.GetPlayerHealth().GetCurrentHP();
        float max = player.GetPlayerHealth().max_hp;
        float duration = 0.75f * (current / max);
        healthBarImage.DOFillAmount(current / max, duration);
    }
}

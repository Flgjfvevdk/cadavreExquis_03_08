using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SC_HealthBar : MonoBehaviour
{
    // cette syntax permet de modifier l'objet dans l'UI de Unity tout en le gardant private
    [SerializeField]
    protected SC_health health;
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

    public virtual void updateHealthBar()
    {
        float current = health.GetCurrentHP();
        float max = health.max_hp;
        float duration = 0.75f * (current / max);
        healthBarImage.DOFillAmount(current / max, duration);
    }
}

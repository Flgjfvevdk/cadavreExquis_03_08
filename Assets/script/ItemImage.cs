using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemImage : MonoBehaviour
{

    public bool shouldAppear;
    [SerializeField]
    private Image sprite;
    // Start is called before the first frame update
    void Start()
    {
        this.sprite.enabled = false;
        this.shouldAppear = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateSprite(bool visibilityState)
    {
        this.sprite.enabled = visibilityState;
    }
}

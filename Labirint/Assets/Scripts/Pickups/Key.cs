using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum KeyColor
{
    Red = 0,
    Green = 1,
    Gold = 2
}

public class Key : Pickup
{
    public KeyColor color;
    private Renderer Render;

    public Material materialRed;
    public Material materialGreen;
    public Material materialGold;
    public override void Picked()
    {
        GameManager.gameManager.AddKey(color);
        Destroy(this.gameObject);
    }
    private void Start()
    {
        Render = GetComponent<Renderer>();
        SetMaterial();
    }
    private void SetMaterial()
    {
        switch (color)
        {
            case KeyColor.Red:
                Render.material = materialRed;
                break;
            case KeyColor.Green:
                Render.material = materialGreen;
                break;
            case KeyColor.Gold:
                Render.material = materialGold;
                break;
        }
    }
}

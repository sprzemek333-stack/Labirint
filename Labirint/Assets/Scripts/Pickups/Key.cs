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
    public override void Picked()
    {
        GameManager.gameManager.AddKey(color);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    public int freezeTime = 10;
    void Update()
    {
        Rotation();
    }
    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(10);
        Destroy(gameObject);
    }
}

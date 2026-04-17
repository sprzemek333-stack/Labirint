using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : Pickup
{
    public int points = 5;
    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        base.Picked();
    }
}

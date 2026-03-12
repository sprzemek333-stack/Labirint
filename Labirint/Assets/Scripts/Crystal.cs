using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Pickup
{
    public int points = 5;
    void Update()
    {
        Rotation();
    }
    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        Destroy(gameObject);
    }
}

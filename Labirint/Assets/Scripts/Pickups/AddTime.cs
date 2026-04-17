using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : Pickup
{
    public int time = 30;
    public override void Picked()
    {
        GameManager.gameManager.AddTime(time);
        base.Picked();
    }
}

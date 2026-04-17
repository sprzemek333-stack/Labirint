using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slip : Pickup
{
    private GameObject player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Picked()
    {
        base.Picked();
    }
}

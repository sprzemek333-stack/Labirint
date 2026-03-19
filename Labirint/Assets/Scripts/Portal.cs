using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal otherPortal;
    public Collider portalCollider;
    public Camera portalCamera;
    public Transform renderSurface;
    public Material portalMaterial;

    private GameObject player;
    private PortalTereport portalTereport;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        portalTereport = GetComponentInChildren<PortalTereport>();

        portalTereport.player = player.transform;
        portalTereport.reciver = otherPortal.transform;
    }
}

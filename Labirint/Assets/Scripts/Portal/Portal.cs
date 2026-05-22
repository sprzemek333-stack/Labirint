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

    private PortalCamera portalCameraComponent;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        portalTereport = GetComponentInChildren<PortalTereport>();

        portalTereport.player = player.transform;
        portalTereport.reciver = otherPortal.transform;
        portalCamera = GetComponentInChildren<Camera>();

        portalCameraComponent = GetComponentInChildren<PortalCamera>();

        //set the Component PortalCamera
        portalCameraComponent.playerCamera = player.GetComponentInChildren<Camera>().transform;
        portalCameraComponent.portal = transform;
        portalCameraComponent.otherPortal = otherPortal.transform;

        renderSurface.GetComponent<MeshRenderer>().material = Instantiate(portalMaterial);

        if (portalCamera.targetTexture != null)
        {
            portalCamera.targetTexture.Release();
        }

        portalCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
    }
    private void Start()
    {
        renderSurface.GetComponent<Renderer>().material.mainTexture = otherPortal.portalCamera.targetTexture;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    private void Update()
    {
        PortalCameraController();
    }
    public void PortalCameraController()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDiffBetweenPortalRotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationDiff =
            Quaternion.AngleAxis(angularDiffBetweenPortalRotation, Vector3.up);

        Vector3 newCameraDirection = portalRotationDiff * playerCamera.forward;

        newCameraDirection = new Vector3(newCameraDirection.x * -1, newCameraDirection.y, newCameraDirection.z * -1);

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}

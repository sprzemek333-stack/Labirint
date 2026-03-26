using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTereport : MonoBehaviour
{
    public Transform player;
    public Transform reciver;
    public bool isInPortal;
    public bool isForceToExitPortal = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInPortal = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInPortal = false;
            isForceToExitPortal = false;
        }
    }
    private void Teleport()
    {
        if (isInPortal && ! isForceToExitPortal)
        {
            

            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up,portalToPlayer);

            if (dotProduct <= 0)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 posisionDiff = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;

                player.position = reciver.position + posisionDiff;
                player.localPosition += player.transform.forward * 0.2f;
                player.position = new Vector3(player.position.x, 0, player.position.z);
                

                isInPortal = false;
                isForceToExitPortal = true;
            }
        }
    }
    private void FixedUpdate()
    {
        Teleport();
    }
}

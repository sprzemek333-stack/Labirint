using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public virtual void Picked()
    {
        Debug.Log("Picked up");
        Destroy(gameObject);
    }
    public void Rotation()
    {
        transform.Rotate(new Vector3(0.5f, 0, 0));
    }
}

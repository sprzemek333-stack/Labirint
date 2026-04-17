using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 5, 0);
    public virtual void Picked()
    {
        //Debug.Log("Picked up");
        Destroy(gameObject);
    }
    void Update()
    {
        Rotate();
    }
    public virtual void Rotate()
    {
        transform.Rotate(rotationSpeed);
    }
}

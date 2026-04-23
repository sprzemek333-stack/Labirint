using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public Transform closePoint;
    public Transform openPoint;

    public bool isOpen = false;

    public float speed = 5f;
    void Start()
    {
        door.position = closePoint.position;
    }
    public void Open()
    {
        isOpen = true;
    }
    public void Close()
    {
        isOpen = false;
    }
    public void Update()
    {
        if (isOpen && Vector3.Distance(door.position,openPoint.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position,openPoint.position,speed * Time.deltaTime);
        }
        else if (!isOpen && Vector3.Distance(door.position, closePoint.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, closePoint.position, speed * Time.deltaTime);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Door[] doors;
    public KeyColor myColor;

    private Animator anim;
    private bool isUnlocked = false;
    private bool canOpen = false; // can the plyer open the look

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.Open();
        }
    }
    public bool CheckKey()
    {
        if (GameManager.gameManager.redKey > 0 && myColor == KeyColor.Red)
        {
            isUnlocked = true;
            GameManager.gameManager.redKey--;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myColor == KeyColor.Green)
        {
            isUnlocked = true;
            GameManager.gameManager.greenKey--;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && myColor == KeyColor.Gold)
        {
            isUnlocked = true;
            GameManager.gameManager.goldKey--;
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !isUnlocked)
        {
            anim.SetBool("Use Key", CheckKey());  
        }
    }
}

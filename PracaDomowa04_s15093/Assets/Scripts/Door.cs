using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    bool doorOpen;


    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            doorOpen = true;
            //Debug.Log("Open");
            DoorControll("DoorOpen");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            //Debug.Log("Open");
            DoorControll("DoorClose");
        }
    }

    void DoorControll (string direction) 
    {
        animator.SetTrigger(direction);
    }
}

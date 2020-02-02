using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligthning : MonoBehaviour
{
    public bool hitted = false;
    //public energyCapacity;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("push");
            hitted = true;
            //animset Hitted
          //  energyCapacity;
        }
    }
}

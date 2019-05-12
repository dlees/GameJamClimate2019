using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCollisionAvoidance : MonoBehaviour
{
    public bool shouldEvade = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            shouldEvade = true;
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        //if (other.CompareTag("Ground"))
        //{
            shouldEvade = false;
        //}
    }
}

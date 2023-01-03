using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform sideOne;
    public Transform sideTwo;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Left"))
            {
                collision.gameObject.transform.position = sideTwo.position;
            } else if (gameObject.CompareTag("Right"))
            {
                collision.gameObject.transform.position = sideOne.position;
            }
        }
    }
}

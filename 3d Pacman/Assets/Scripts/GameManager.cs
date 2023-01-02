using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float cols = 50f;
    [SerializeField] float rows = 50f;
    [SerializeField] float offset = 2f;

    [SerializeField] Transform startingPoint;

    [SerializeField] GameObject point;

    GameObject newPoint;
    Transform newPointPos;

    private void Start()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                newPoint = Instantiate(point, startingPoint.position, Quaternion.identity);

                newPoint.transform.position = new Vector3(newPoint.transform.position.x - i, newPoint.transform.position.y, newPoint.transform.position.z + j);
            }
        }        
    }

}

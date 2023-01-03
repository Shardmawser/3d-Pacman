using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform startingPos;

    public float width;
    public float height;
    public float spacing;

    public GameObject point;
    private void Start()
    {
        int numX =  Mathf.RoundToInt(width/spacing);
        int numZ =  Mathf.RoundToInt(height/spacing);

        float xPos;
        float zPos;


        for(int i = 0; i < numZ; i++)
        {
            for(int j= 0; j < numX; j++)
            {
                xPos = j * spacing - width + spacing;
                zPos = i * spacing - height + spacing;

                Vector3 positon = new Vector3(xPos, 1.423f, zPos);

                GameObject go = Instantiate(point, positon, Quaternion.identity);

            }
        }
    }

}

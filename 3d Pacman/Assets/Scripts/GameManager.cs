using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab; // the prefab to instantiate
    public float width; // width of the area
    public float height; // height of the area
    public float spacing; // spacing between the game objects

    void Start()
    {
        // calculate the number of game objects to instantiate in the x and y directions
        int numX = Mathf.RoundToInt(width / spacing);
        int numY = Mathf.RoundToInt(height / spacing);

        // iterate through the x and y directions and instantiate game objects
        for (int x = 0; x < numX; x++)
        {
            for (int y = 0; y < numY; y++)
            {
                // calculate the position of the game object
                float xPos = x * spacing - width / 2f + spacing / 2f;
                float yPos = y * spacing - height / 2f + spacing / 2f;

                // create a new game object at the calculated position
                Vector3 position = new Vector3(xPos, 0f, yPos);
                GameObject go = Instantiate(prefab, position, Quaternion.identity);

                // set the parent of the game object to this transform
                go.transform.parent = transform;
            }
        }
    }

}

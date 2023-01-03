using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject point;

    private void Start()
    {
        foreach (Transform t in spawnPoints)
        {
            Instantiate(point, new Vector3(t.position.x, 1.423f, t.position.z), Quaternion.identity);
        }
    }

}

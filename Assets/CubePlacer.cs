﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubePlacer
{
    static List<Transform> cubes;

    public static void PlaceCube(Vector3 position,Color color,Transform cube) {
        Transform newCube = GameObject.Instantiate(cube,position,Quaternion.identity);
        newCube.GetComponentInChildren<MeshRenderer>().material.color = color;

        if (cubes == null) {
            cubes = new List<Transform>();
        }

        cubes.Add(newCube);
    }

    public static void RemoveCube(Vector3 postion,Color color) {
        for (int i = 0; i < cubes.Count; i++) {
            if (cubes[i].position == postion && cubes[i].GetComponentInChildren<MeshRenderer>().material.color == color) {
                GameObject.Destroy(cubes[i].gameObject);
                cubes.RemoveAt(i);
            }
        }
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrid : MonoBehaviour {

    public List<GridCube> cubes = new List<GridCube>();
    public float raiseRange = 2.5f;
    public float maxRaiseHeight = 1;

    public int playerCount = 2;
    public List<Color> playerColors = new List<Color>();

    void Update() {
        SetRaiseAmount(new Vector2(Mathf.Sin(Time.time) * 4, 0), 2, 0);
        SetRaiseAmount(new Vector2(0, Mathf.Sin(Time.time) * 4), 2, 1);
    }

    public void SetRaiseAmount(Vector2 location, float a, int player) {
        foreach(GridCube cube in cubes) {
            float distance = raiseRange / Vector2.Distance(location, new Vector2(cube.transform.position.x, cube.transform.position.z));
            float clampedDistance = Mathf.Clamp01(distance);
            float amount = clampedDistance * a;
            cube.SetRaiseAmount(amount, player);
        }
    }

    [ContextMenu("Find Cubes")]
    private void FindCubes() {
        cubes = new List<GridCube>(gameObject.GetComponentsInChildren<GridCube>());

        foreach(GridCube c in cubes) {
            c.playerCount = playerCount;
            c.colors = playerColors;
        }
    }
}
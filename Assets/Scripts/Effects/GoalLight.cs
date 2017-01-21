﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLight : MonoBehaviour {

    private Material mat;

    private Color invisibleColor = new Color(1,1,1,0);
    private Color flashColor;
    private float flashColorTime = 0;

    private int playerID = 0;

    void Start() {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update() {
        mat.SetColor("_Tint",
            Color.Lerp(invisibleColor, flashColor, flashColorTime)
            );

        GameManager.instance.PlayerObjects[playerID].GetComponent<PlayerBall>().goalColorOffset = flashColorTime;

        flashColorTime = Mathf.Lerp(flashColorTime, 0, 0.1f);
    }

    public void FlashColor(Color c, int player) {
        flashColor = c;
        flashColorTime = 2;

        playerID = player;

        invisibleColor = new Color(c.r, c.g, c.b, 0);
    }
}

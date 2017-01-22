﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private bool hasScored = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -100) {
            DestroyBall();
        }
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Goal" && !hasScored) {
			Debug.Log("Ayy lmao this is a goal!");
            col.gameObject.GetComponent<Goal>().OnScoreEvent();
            hasScored = true;
            DestroyBall();

            return;
		}

        if(col.impulse.magnitude >= 110f) {
            SoundManager.Instance.PlaySFX(SFX.BallBoop);
        }
	}

	void DestroyBall() {
        GameManager.instance.Balls.Remove(gameObject);
		Destroy(this.gameObject);
	}
}

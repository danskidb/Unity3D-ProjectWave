﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Goal" ) {
			Debug.Log("Ayy lmao this is a goal!");
			col.gameObject.GetComponent<Goal>().OnScoreEvent();
			StartCoroutine(DestroyAfterDelay());
		}
	}

	IEnumerator DestroyAfterDelay() {
		yield return new WaitForSeconds(0.5f);
		Destroy(this.gameObject);
	}
}

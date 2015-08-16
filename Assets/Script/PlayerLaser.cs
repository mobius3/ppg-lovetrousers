using UnityEngine;
using System.Collections;

public class PlayerLaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Z)) {
			transform.GetChild(0).gameObject.SetActive(true);
		} else {
			transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}

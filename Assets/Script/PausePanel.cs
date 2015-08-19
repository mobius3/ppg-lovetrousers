using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(1024,640,true);
		Time.timeScale = 0.0f;
	}

	public void Unpause() { 
		Time.timeScale = 1.0f;
		this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

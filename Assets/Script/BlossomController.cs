using UnityEngine;
using System.Collections;

public class BlossomController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BackgroundScroller.Speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") *3);
        Vector3 position = transform.position;
        //position += transform.up;
        transform.position = position;
        Debug.Log("x" + Input.GetAxis("Horizontal") + "y" + transform.right + "z" + transform.up);
        BackgroundScroller.Speed = transform.up.x;
	}
}

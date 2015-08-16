using UnityEngine;
using System.Collections;

public class BlossomController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BackgroundScroller.Speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * 3);
        transform.position += transform.up * Input.GetAxis("Vertical");
        Debug.Log("x" + Input.GetAxis("Horizontal") + "y" + transform.right + "z" + transform.up);
		BackgroundScroller.Speed = -Input.GetAxis("Vertical")*transform.right.y;
		BackgroundScroller.Ypos = -transform.position.y;
	}
}

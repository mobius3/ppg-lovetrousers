using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    static public float Speed = 0f;
	static public float Ypos = 0f;
    public float Factor;
    private float pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.mainTextureOffset += new Vector2(Speed * Factor * Time.deltaTime, 0);
		Vector3 position = transform.position;
		position.y = Ypos * Factor;
		transform.position = position;
	}
}

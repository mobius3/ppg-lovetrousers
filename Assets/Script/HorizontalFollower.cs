using UnityEngine;
using System.Collections;

public class HorizontalFollower : MonoBehaviour {

    public Transform follow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        	transform.position = new Vector3(follow.position.x, follow.position.y > 0 ? follow.position.y : 0, transform.position.z);
	}
}

using UnityEngine;
using System.Collections;

public class HorizontalFollower : MonoBehaviour {

    public Transform follow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(follow.position.x, transform.position.y, transform.position.z);
	}
}

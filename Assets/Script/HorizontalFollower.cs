using UnityEngine;
using System.Collections;

public class HorizontalFollower : MonoBehaviour {

    public Transform follow;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	// parte que o JP arrumou
	/*
	if Camera is front
		go Back 
		else
	    stay

	Summon compiler cast build
	*/

	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.z = follow.position.z;
		if (PPGController.speed.magnitude > 0.2f) {
			position = Vector3.MoveTowards(position, follow.position + PPGController.speed*5f, 5f);
		} else {
			position = Vector3.SmoothDamp(position, follow.position, ref velocity, 2f);
			BackgroundScroller.Speed = velocity.x/10;
		}
		position.z = transform.position.z;
		if (position.y < 0f)
			position.y = transform.position.y;
		transform.position = position;
		//transform.position = new Vector3(follow.position.x, follow.position.y > 0 ? follow.position.y : 0, transform.position.z);
		BackgroundScroller.Ypos = -transform.position.y;
	}

    public void LindinhaFormation()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    public void DocinhoFormation()
    {

    }

    public void FlorzinhaFormation()
    {

    }
}

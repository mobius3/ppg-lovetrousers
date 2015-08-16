using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform follow;
    Rigidbody2D body;
    Vector3 target = Random.insideUnitSphere * Random.Range(3, 6);
    Vector3 velocity = Vector3.zero;
    float maxSpeed = Random.Range(10, 60) * 1.0f;
    float time = Random.Range(30, 80) * 0.01f;

	// Use this for initialization
	void Start () {
        body = transform.GetComponent<Rigidbody2D>();
        transform.position = follow.position + follow.up * -10;
        Position();
	}

    void Position()
    {
        transform.position = Vector3.SmoothDamp(transform.position, follow.position - target, ref velocity, time, maxSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        Position();
	}
}

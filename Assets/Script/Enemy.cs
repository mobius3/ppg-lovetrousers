using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform follow;
    Rigidbody2D body;
    Vector3 target = Random.insideUnitSphere * Random.Range(3, 6);
    int speed = Random.Range(0, 20);

	float hp = Random.Range(1,10);

	// Use this for initialization
	void Start () {
        body = transform.GetComponent<Rigidbody2D>();
        transform.position = follow.position + follow.up * 20;
        Position();
	}

    void Position()
    {
        transform.position = Vector3.Lerp(transform.position, follow.position + follow.up + target, speed/100.0f);
    }
	
	// Update is called once per frame
	void Update () {
        Position();
	}

	public void TakeDamage(float amount) {
		hp -= amount;
		if (hp <= 0f) {
			Destroy(this.gameObject);
		}
	}
	
}

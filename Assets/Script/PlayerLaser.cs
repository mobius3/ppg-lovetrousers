using UnityEngine;
using System.Collections;

public class PlayerLaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	/*void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("Esenemy> "+collision.gameObject.name);
		if (collision.gameObject.tag == "Enemy") {
			collision.gameObject.GetComponent<Enemy>().TakeDamage(10f);//Destroy(collision.gameObject);
		}
	}*/

	void OnTriggerEnter2D(Collider2D coll) {
		//Debug.Log("Tsenemy> "+coll.gameObject.name);
		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.GetComponent<Enemy>().TakeDamage(10f);//Destroy(collision.gameObject);
    	}
	}
}

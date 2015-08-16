using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Transform follow;
    Rigidbody2D body;
    Vector3 target;
    Vector3 velocity = Vector3.zero;
    public Text scoreValueText;
    float maxSpeed = Random.Range(10, 60) * 1.0f;
    float time = Random.Range(30, 80) * 0.01f;
    static Enemy boss = null;

	float hp = Random.Range(1,10);
    private static int destroyCount = 0;

	// Use this for initialization
	void Start () {
        target = Random.insideUnitSphere * Random.Range(3, 6);
        body = transform.GetComponent<Rigidbody2D>();
        transform.position = follow.position + follow.up * -25;
        Position();

		transform.localScale *= Random.Range(1, 3);;

		if (destroyCount >= 200 && boss == null) {
			Boss();
            boss = this;
		}
	}

    void Position()
    {
        transform.position = Vector3.SmoothDamp(transform.position, follow.position - target, ref velocity, time, maxSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        Position();
	}

	public void TakeDamage(float amount) {
		hp -= amount;
		if (hp <= 0f) {
            destroyCount++;
			Destroy(this.gameObject);
            scoreValueText.text = destroyCount.ToString();
            if (boss == this)
            {
                Application.LoadLevel("GameWinScene");
            }
		}
	}

	public void Boss() {
		hp = 100f;
		//maxSpeed = 5f;
		time = 0.8f;
		transform.localScale *= 10f;
		this.gameObject.name = "Boss brain";
        Debug.LogError("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOSSSSSSSSSS");
	}
	
}

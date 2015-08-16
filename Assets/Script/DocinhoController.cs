using UnityEngine;
using System.Collections;

public class DocinhoController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LindinhaFormation()
    {
        transform.localPosition = new Vector3(-0.25f, 0, 0);
    }

    public void DocinhoFormation()
    {
        transform.localPosition = new Vector3(0.0f, 0.25f, 0);
    }

    public void FlorzinhaFormation()
    {
        transform.localPosition = new Vector3(0.25f, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.parent.GetComponent<PPGController>().TakeDamage(10f);
            collision.gameObject.GetComponent<Enemy>().TakeDamage(10f);
        }
    }
}

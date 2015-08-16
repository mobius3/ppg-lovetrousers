using UnityEngine;
using System.Collections;

public class FlorzinhaController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void LindinhaFormation()
    {
        transform.localPosition = new Vector3(0.25f, 0, 0);
    }

    public void DocinhoFormation()
    {
        transform.localPosition = new Vector3(0.25f, 0, 0);
    }

    public void FlorzinhaFormation()
    {
        transform.localPosition = new Vector3(0, 0.25f, 0);
    }
}

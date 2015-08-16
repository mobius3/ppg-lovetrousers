using UnityEngine;
using System.Collections;

public enum Girl
{
    FLORZINHA = 1,
    LINDINHA = 2,
    DOCINHO = 3
}

public class PPGController : MonoBehaviour {

    public Girl mainGirl
    {
        get
        {
            return _mainGirl;
        }
        set
        {
            _mainGirl = value;
            swapMainGirl(value);
        }
    }
    private Girl _mainGirl;

    public FlorzinhaController florzinha;
    public LindinhaController lindinha;
    public DocinhoController docinho;

	// Use this for initialization
	void Start () {
        mainGirl = Girl.LINDINHA;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * 3);
        transform.position += transform.up * Input.GetAxis("Vertical");
        BackgroundScroller.Speed = -Input.GetAxis("Vertical") * transform.right.y;
        BackgroundScroller.Ypos = -transform.position.y;

        if (Input.GetKeyDown("space")) { 
            switch (mainGirl) {
                case Girl.FLORZINHA: mainGirl = Girl.LINDINHA; break;
                case Girl.LINDINHA: mainGirl = Girl.DOCINHO; break;
                case Girl.DOCINHO: mainGirl = Girl.FLORZINHA; break;
            }
        }
	}

    void swapMainGirl(Girl girl)
    {
        switch (mainGirl)
        {
            case Girl.FLORZINHA: {
                Debug.Log("FLORZINHA formation!");
                florzinha.FlorzinhaFormation();
                docinho.FlorzinhaFormation();
                lindinha.FlorzinhaFormation();
            }
            break;

            case Girl.LINDINHA:
            {
                Debug.Log("LINDINHA formation!");
                florzinha.LindinhaFormation();
                docinho.LindinhaFormation();
                lindinha.LindinhaFormation();
            }
            break;

            case Girl.DOCINHO:
            {
                Debug.Log("DOCINHO formation!");
                florzinha.DocinhoFormation();
                docinho.DocinhoFormation();
                lindinha.DocinhoFormation();
            }
            break;
        }
    }
}

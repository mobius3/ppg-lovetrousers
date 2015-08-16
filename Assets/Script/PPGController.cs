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
    public AudioSource pxziou;
    public AudioSource jet;

	private Animator girlsAnimator;

	public static Vector3 speed = Vector3.zero;
    private Vector3 prevSpeed;

	// Use this for initialization
	void Start () {
		girlsAnimator = GetComponent<Animator>();
		mainGirl = Girl.LINDINHA;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos1 = transform.position;
		switch (mainGirl)
		{
			case Girl.FLORZINHA: {
				FlorzinhaMovement();
			}
			break;
			case Girl.LINDINHA: {
				LindinhaMovement();
			}
			break;
			case Girl.DOCINHO: {
				DocinhoMovement();
			}
			break;
		}
		speed = transform.position - pos1;
        Debug.Log(" " + speed.sqrMagnitude + " " + prevSpeed.sqrMagnitude);
        if (speed.sqrMagnitude > 0 && prevSpeed.sqrMagnitude == 0)
        {
            pxziou.Play();
        }
        prevSpeed = speed;

        if (Input.GetKeyDown("space")) { 
            switch (mainGirl) {
                case Girl.FLORZINHA: mainGirl = Girl.LINDINHA; break;
                case Girl.LINDINHA: mainGirl = Girl.DOCINHO; break;
                case Girl.DOCINHO: mainGirl = Girl.FLORZINHA; break;
            }
        }   

        jet.volume = speed.magnitude;
        
	}

    void swapMainGirl(Girl girl)
    {
		girlsAnimator.SetInteger("MainGirl", (int) girl);
		Debug.Log(girl+" formation!");
        /*switch (mainGirl)
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
        }*/
    }

	void FlorzinhaMovement() {
		transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * 5);
		Vector3 position = transform.position;
		position += transform.up * Input.GetAxis("Vertical");
		if (position.y > -13.75f)
			transform.position = position;
        else
        {
            if (transform.rotation.eulerAngles.z > 180)
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 315.0f));
            else
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 45.0f));
        }
		BackgroundScroller.Speed = -Input.GetAxis("Vertical") * transform.right.y;
		//BackgroundScroller.Ypos = -transform.position.y;
	}

	void LindinhaMovement() {
		Vector3 position = transform.position;
		position += Vector3.up * Input.GetAxis("Vertical");
		position += Vector3.right * Input.GetAxis("Horizontal");

		if (position.y > -13.75f)
			transform.position = position;
        else
        {
            if (transform.rotation.eulerAngles.z > 180)
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 315.0f));
            else
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 45.0f));
        }
		BackgroundScroller.Speed = Input.GetAxis("Horizontal");
		//BackgroundScroller.Ypos = -transform.position.y;
	}

	void DocinhoMovement() {
		transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * 5);
		Vector3 position = transform.position;
		position += transform.up * Input.GetAxis("Vertical");
		if (position.y > -13.75f)
			transform.position = position;
        else
        {
            if (transform.rotation.eulerAngles.z > 180)
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 315.0f));
            else
                transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 45.0f));
        }
		BackgroundScroller.Speed = -Input.GetAxis("Vertical") * transform.right.y;
		//BackgroundScroller.Ypos = -transform.position.y;
	}
}

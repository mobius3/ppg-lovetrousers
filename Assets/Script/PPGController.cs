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
    private float turnFactor;

	private Animator girlsAnimator;
	private PlayerLaser[] lasers;

	public static Vector3 speed = Vector3.zero;
    private Vector3 prevSpeed;

	// Use this for initialization
	void Start () {
		girlsAnimator = GetComponent<Animator>();
		mainGirl = Girl.FLORZINHA;
		lasers = GetComponentsInChildren<PlayerLaser>();
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

		transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * turnFactor);
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

		speed = transform.position - pos1;
        
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
        turnFactor = (Input.GetKey(KeyCode.UpArrow)) ? 5 : 10;
        Debug.Log(" " + turnFactor + " " + Input.GetAxis("Vertical"));

		if (Input.GetKey(KeyCode.Z)) {
			foreach(PlayerLaser laser in lasers) 
				laser.gameObject.SetActive(true);
            turnFactor = turnFactor == 10 ? 3 : 2;
		} else {
			foreach(PlayerLaser laser in lasers)
				laser.gameObject.SetActive(false);
		}
	}

    void swapMainGirl(Girl girl)
    {
		girlsAnimator.SetTrigger("ChangeGirl");
		girlsAnimator.SetInteger("MainGirl", (int) girl);
		Debug.Log(girl+" formation!");

    }

	void FlorzinhaMovement() {
		/*
		transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * turnFactor);
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
		*/
	}

	void LindinhaMovement() {
		/*Vector3 position = transform.position;
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
		*/
	}

	void DocinhoMovement() {
		/*transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * 3);
        transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * turnFactor);
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
		*/
	}
}

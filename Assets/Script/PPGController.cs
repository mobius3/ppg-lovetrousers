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

	private Animator girlsAnimator;
	private PlayerLaser[] lasers;

	public static Vector3 speed = Vector3.zero;

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

		transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * 3);
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

        if (Input.GetKeyDown("space")) { 
            switch (mainGirl) {
                case Girl.FLORZINHA: mainGirl = Girl.LINDINHA; break;
                case Girl.LINDINHA: mainGirl = Girl.DOCINHO; break;
                case Girl.DOCINHO: mainGirl = Girl.FLORZINHA; break;
            }
        }

		if (Input.GetKey(KeyCode.Z)) {
			foreach(PlayerLaser laser in lasers) 
				laser.gameObject.SetActive(true);
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

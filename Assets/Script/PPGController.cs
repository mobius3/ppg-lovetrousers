using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    private Girl _mainGirl = Girl.FLORZINHA;

    public FlorzinhaController florzinha;
    public LindinhaController lindinha;
    public DocinhoController docinho;
	public AudioSource[] girlsTheme;
    public AudioSource pxziou;
    public AudioSource jet;
	public AudioSource laserSound;
    private float turnFactor;
    private float health;
    public Text healthValueText;
	public Text laserPowerText;

	private Animator girlsAnimator;
	private PlayerLaser[] lasers;

	bool chargingLaser {
		get;
		set;
	}

	float laserPower = 100f;

	const float laserDropRate = 20f;
	const float laserFillRate = 10f;

	public static Vector3 speed = Vector3.zero;
    private Vector3 prevSpeed;

	// Use this for initialization
	void Start () {
		girlsAnimator = GetComponent<Animator>();
		//mainGirl = Girl.FLORZINHA;
		lasers = GetComponentsInChildren<PlayerLaser>();
        health = 100;
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
		if (Input.GetAxis("Vertical") > 0f)
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

		if (Input.GetAxis("Vertical") > 0f)
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
        //Debug.Log(" " + turnFactor + " " + Input.GetAxis("Vertical"));

		if (!chargingLaser && Input.GetKey(KeyCode.Z)) {
			foreach(PlayerLaser laser in lasers) 
				laser.gameObject.SetActive(true);
            turnFactor = turnFactor == 10 ? 3 : 2;
			laserSound.volume = laserPower/100f+0.7F;
			laserPower -= laserDropRate*Time.deltaTime;
			if (laserPower <= 30f) {
				laserPowerText.color = Color.red;
				if (laserPower <= 0f) {
					chargingLaser = true;
				}
			}
		} else {
			foreach(PlayerLaser laser in lasers)
				laser.gameObject.SetActive(false);

			laserPower += laserFillRate*Time.deltaTime;
			laserSound.volume = 0f;
			if (laserPower >= 30f) {
				chargingLaser = false;
				laserPowerText.color = Color.green;
				if (laserPower >= 100f) {
					laserPower = 100f;
				}
			} else {
				chargingLaser = true;
				laserPowerText.color = Color.red;
			}
		}
		laserPowerText.text = laserPower.ToString("0")+ '%';
	}

    void swapMainGirl(Girl girl)
    {
		girlsAnimator.SetTrigger("ChangeGirl");
		girlsAnimator.SetInteger("MainGirl", (int) girl);
		girlsTheme[(int) girl - 1].Play();
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

    public void TakeDamage(float damage)
    {
		girlsAnimator.SetTrigger("Damaged");
    	health -= damage/10.0f;
        healthValueText.text = health.ToString() + '%';
        if (health <= 0.0f)
            Application.LoadLevel("GameOverScene");

    }
}

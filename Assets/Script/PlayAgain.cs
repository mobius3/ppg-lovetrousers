using UnityEngine;
using System.Collections;

public class PlayAgain : MonoBehaviour {
	

	// Update is called once per frame
	public void Replay () {
		Enemy.destroyCount = 0;
		Application.LoadLevel("GameScene");
	}
}

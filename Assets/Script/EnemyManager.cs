using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    public Transform follow;
    public GameObject cerebroLoucoPrefab;
    public int maxEnemies;

	private bool spawning = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!spawning && transform.childCount < maxEnemies)
		{
			StartCoroutine(SpawnEnemies());
		}
	}

	IEnumerator SpawnEnemies() {
		while(transform.childCount < maxEnemies) {
			spawning = true;
			yield return new WaitForSeconds(1.0f);
			GameObject enemyObj = GameObject.Instantiate(cerebroLoucoPrefab);
			enemyObj.GetComponent<Enemy>().follow = follow;
			//enemyObj.transform.position = follow.position + follow.up * 3;
			enemyObj.transform.SetParent(this.transform);
		}
		spawning = false;
	}

}

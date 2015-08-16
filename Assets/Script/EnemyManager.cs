using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    public Transform follow;
    public GameObject cerebroLoucoPrefab;
    public List<GameObject> enemies = new List<GameObject>();
    public int maxEnemies;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
	}

    public IEnumerator SpawnEnemy()
    {
        while (enemies.Count < maxEnemies)
        {
            yield return new WaitForSeconds(1.0f);
            GameObject enemyObj = GameObject.Instantiate(cerebroLoucoPrefab);
            enemyObj.GetComponent<Enemy>().follow = follow;
            //enemyObj.transform.position = follow.position + follow.up * 3;
            enemies.Add(enemyObj);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwerManager : MonoBehaviour {
	//Singleton Statement
	public static SpanwerManager instance = null;
	void Awake() {
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}//End of Singleton Statement

	public List<Transform> spawnPoints;
	public float timeBetweenEnemySpawns;
	public GameObject enemyPrefab;


	//Private Zone
	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		spawnEnemy ();
	}

	void spawnEnemy()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenEnemySpawns){
			Instantiate (enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.ToArray().Length)].transform.position, Quaternion.identity);
			timer = 0;
		}
	}
}

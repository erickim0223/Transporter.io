using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject enemy;
	float randX;
	float randY;
	float currentX;
	float currentY;
	public float spawnWidth = 2.0f;
	public float spawnHeight = 2.0f;
	Vector2 whereToSpawn;
	public float spawnRate =  2f;
	float nextSpawn;

	void Start (){
		currentX = transform.position.x;
		currentY = transform.position.y;
	}

	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range(-1 * spawnWidth, spawnWidth);
			randY = Random.Range(-1 * spawnHeight, spawnHeight);
			whereToSpawn = new Vector2 (randX + currentX, randY + currentY);
			Instantiate (enemy, whereToSpawn, Quaternion.identity);
		}


	}
}
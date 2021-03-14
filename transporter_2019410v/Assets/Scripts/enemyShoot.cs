using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
  public float speed;
  public float stoppingDistance;
  public float retreatDistance;
  public int EnemyLives = 6;
  
  private Transform player;
  private float timeBtwShots;
  public float startTimeBtwShots;
  
  public GameObject projectile;
  private Renderer rend;
  
  
  void Start() 
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    timeBtwShots = startTimeBtwShots;
    rend = GetComponent<Renderer> ();
  }
  
  void Update()
  {
    if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
    {
      transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    } 
    else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
    {
      transform.position = this.transform.position;
    }
    else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
    {
      transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
    }
    
    if(timeBtwShots <= 0){
      Instantiate(projectile, transform.position, Quaternion.identity);
      timeBtwShots = startTimeBtwShots;
    } else {
      timeBtwShots -= Time.deltaTime;
    }
  }
  
  void OnCollisionEnter2D(Collision2D collision){
  if (collision.gameObject.tag == "bullet") {
    EnemyLives -= 1;
    StopCoroutine("HitEnemy");
    StartCoroutine("HitEnemy");
  }
  }
  
  IEnumerator HitEnemy(){
		// color values are R, G, B, and alpha, each divided by 100
		rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
		if (EnemyLives < 1){
			Destroy(gameObject);
		}
		else yield return new WaitForSeconds(0.5f);
		rend.material.color = Color.white;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public int EnemyLives = 3;
    private Renderer rend;
  
    // Start is called before the first frame update
    void Start()
    {
      rend = GetComponent<Renderer> ();
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "bullet") {
			EnemyLives -= 1;
			StopCoroutine("HitEnemy");
			StartCoroutine("HitEnemy");
		}
		else if (collision.gameObject.tag == "Player") {
			EnemyLives -= EnemyLives;
			rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
      Destroy(gameObject);
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

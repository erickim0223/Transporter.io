using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    
    private Transform player;
    private Vector2 target;
    public GameObject hitEffect;
    
  
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").transform;
      target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag != "enemyShooter" && collision.gameObject.tag != "enemyFollow"){
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
      }
    }
}

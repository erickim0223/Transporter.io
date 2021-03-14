using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float movespeed = 5f;
    public Camera cam;

    Vector3 mouseposition;
    Vector3 changedposition;
    Vector3 deltaposition;

    Vector2 velocity;
    Vector2 movement;
    Vector2 mousePos;

    Rigidbody2D shipbody;  
    
    //Health 
    public int maxHealth = 15;
    public int currentHealth;
    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        shipbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
       mouseposition.z = 0;
       changedposition = gameObject.transform.position;

       deltaposition = (mouseposition - changedposition).normalized;
       //Debug.Log(deltaposition);
       shipbody.velocity = deltaposition*3;

       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

       //movement.x = Input.GetAxisRaw("Horizontal");
       //movement.y = Input.GetAxisRaw("Verticle");
       
       // if (Input.GetKeyDown(KeyCode.Space)){
       //   TakeDamage(2);
       // }
    }
    
    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - shipbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        shipbody.rotation = angle;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.tag == "PickUp") 
      {
        StartCoroutine(DestroyThis(other));
        GetComponent<AudioSource>().Play();
      }
    }
    
    void OnCollisionEnter2D(Collision2D collision){
		  if (collision.gameObject.tag == "enemyFollow") {
			  TakeDamage(2);
		  }
      else if (collision.gameObject.tag == "projectile") {
			  TakeDamage(1);
		  }
      
      if(currentHealth == 0) {
        //CHANGE TO LOSE SCENE
      }
	  }
    
    void TakeDamage(int damage) 
    {
      currentHealth -= damage;
      healthbar.SetHealth(currentHealth);
    }
    
    IEnumerator DestroyThis(Collider2D other){
      yield return new WaitForSeconds(1f);
      other.gameObject.SetActive(false);
    }
}

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


    // Start is called before the first frame update
    void Start()
    {
        shipbody = GetComponent<Rigidbody2D>();
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

    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - shipbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        shipbody.rotation = angle;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("PickUp")) 
        {
          StartCoroutine(DestroyThis(other));
          GetComponent<AudioSource>().Play();
        }
    }
    
    IEnumerator DestroyThis(Collider2D other){
      yield return new WaitForSeconds(1f);
      other.gameObject.SetActive(false);
    }
}

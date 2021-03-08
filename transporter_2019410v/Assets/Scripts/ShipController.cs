using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Vector3 mouseposition;
    Vector3 changedposition;
    Vector3 deltaposition;
    Vector2 velocity;
    Rigidbody2D shipbody;  


    // Start is called before the first frame update
    void Start()
    {
        shipbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       mouseposition.z = 0;
       changedposition = gameObject.transform.position;

       deltaposition = (mouseposition - changedposition).normalized;
       //Debug.Log(deltaposition);
       shipbody.velocity = deltaposition;
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

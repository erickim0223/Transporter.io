using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivered : MonoBehaviour
{
  private float originalY;
  public float strength = 0.5f;

  void Start(){
        this.originalY = this.transform.position.y;
  }

  void Update() {
        transform.position = new Vector2(transform.position.x,
        originalY + ((float)Mathf.Sin(Time.time) * strength));
  }


  void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
              GetComponent<AudioSource>().Play();
              StartCoroutine(DestroyThis()); }
   }

  IEnumerator DestroyThis(){
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
   }
}

using UnityEngine;

public class CameraControl2DLERP : MonoBehaviour {

	public GameObject Player;

	void FixedUpdate () {
		Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)Player.transform.position, Time.fixedDeltaTime);
		//transform.position = new Vector3 (pos.x, pos.y, transform.position.y);
		transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
	}
}

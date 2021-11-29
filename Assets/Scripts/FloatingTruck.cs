/*
Create floating truck that move up and hides
*/

using UnityEngine;

public class FloatingTruck : MonoBehaviour {

	private float moveSpeed = 3;

	void Start() {
		Invoke("DestroyFloatingTruck", 0.3f);
	}

	void Update() {
		transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
	}

	void DestroyFloatingTruck() {
		Destroy(gameObject);
	}
}

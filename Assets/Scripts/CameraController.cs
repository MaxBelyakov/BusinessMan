using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 targetPosition;
    public GameObject cameraTarget;
    public float cameraMoveSpeed;

    private static bool cameraExists;

	void Start () {
        /* First camera will transfer between scenes, duplicates will destroy */
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
	
	void Update () {
        /* Move camera follow the player */
        targetPosition = new Vector3(cameraTarget.transform.position.x, cameraTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);
	}
}
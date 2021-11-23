using UnityEngine;

/* Police station behavior */

public class PoliceStation : MonoBehaviour {

    public GameObject police;
    private Vector3 car_position;

    void Start () {
        /* Create new police car. Temporary */
        if (!GameObject.Find("police(Clone)"))
        {
            car_position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);
            var police_car = Instantiate(police, car_position, Quaternion.identity);
            police_car.transform.SetParent(gameObject.transform);
        }
	}
}
using UnityEngine;

public class FreePlaceEnter : MonoBehaviour {

    public GameObject textField; //Connected to Text Prefab
    public GameObject building; //Connected to building Prefab
    public GameObject manager; //Connected to manager Prefab
    private bool build_request = false;
    private bool buy_manager_request = false;
    private bool buy_truck_request = false;
    private GameObject text;

    private void Update() {
        /* Waiting for money request */
        if (Input.GetButtonDown("Fire1"))
        {
            /* Create new building */
            if (build_request)
            {
                var new_building = Instantiate(building, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
                new_building.transform.SetParent(GameObject.Find("Buildings").transform);
                new_building.transform.tag = "Buildings";
                Destroy(gameObject);
            }
            /* Hire manager */
            if (buy_manager_request)
            {
                /* Searching free tables */
                foreach (GameObject child in GameObject.FindGameObjectsWithTag("WorkTable"))
                {
                    if (child.transform.childCount == 0)
                    {
                        var manager_position = new Vector3(child.transform.position.x, child.transform.position.y + 0.3f, child.transform.position.z);
                        var new_manager = Instantiate(manager, manager_position, Quaternion.Euler(Vector3.zero));
                        new_manager.transform.SetParent(child.transform);
                        break;
                    }
                }
            }
        }
    }

    /* Show text */
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "player_0")
        {
            var text_position = new Vector3(collision.transform.position.x + 1.7f, collision.transform.position.y + 0.7f, collision.transform.position.z);
            text = Instantiate(textField, text_position, Quaternion.Euler(Vector3.zero));

            text.GetComponent<TextController>().SelectText("buy", gameObject.name);
            text.transform.SetParent(collision.transform);

            if (gameObject.name == "buyManagerCell")
                buy_manager_request = true;
            else if (gameObject.name == "buyTruckCell")
                buy_truck_request = true;
            else
                build_request = true;
        } 
    }

    /* Hide text */
    private void OnTriggerExit2D(Collider2D collision) {
        Destroy(text);
        build_request = false;
        buy_truck_request = false;
        buy_manager_request = false;
    }
}
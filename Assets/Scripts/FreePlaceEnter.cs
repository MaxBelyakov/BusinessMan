using UnityEngine;
using UnityEngine.SceneManagement;

public class FreePlaceEnter : MonoBehaviour {

    public GameObject textField; //Connected to Text Prefab
    public GameObject building; //Connected to building Prefab
    public GameObject manager; //Connected to manager Prefab
    public GameObject truck; //Connected to truck Prefab
    private bool build_request;
    private bool buy_manager_request;
    private bool buy_truck_request;
    private bool add_truck_request;
    private GameObject text;
    private int building_cost;

    private void Start() {
        /* Get buildings costs from Economics */
        if (building.name == "lumber")
            building_cost = Economics.lumber_cost;
        else if (building.name == "blacksmith")
            building_cost = Economics.blacksmith_cost;
        else if (building.name == "mine")
            building_cost = Economics.mine_cost;
    }

    private void Update() {
        /* Waiting for money request */
        if (Input.GetButtonDown("Fire1"))
        {
            /* Create new building */
            if (build_request && Economics.GetMoney(building_cost, text))
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
                        if (!Economics.AddManager(text))
                            break;
                        var manager_position = new Vector3(child.transform.position.x, child.transform.position.y + 0.3f, child.transform.position.z);
                        var new_manager = Instantiate(manager, manager_position, Quaternion.Euler(Vector3.zero));
                        new_manager.transform.SetParent(child.transform);
                        break;
                    }
                }
            }

            /* Buy trucks */
            if (buy_truck_request)
                Economics.BuyTruck(text);
            
            /* Add truck to building */
            if (add_truck_request)
            {
                if (Economics.truck_in_inventory)
                {
                    WorldScenario.add_truck_to_world = true;
                    Economics.truck_in_inventory = false;
                } else
                    text.GetComponent<TextController>().SelectText("other", "no_truck_contract");
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
            else if (gameObject.name == "addTruckCell")
                add_truck_request = true;
            else
                build_request = true;
        } 
    }

    /* Hide text */
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "player_0")
        {
            Destroy(text);
            build_request = false;
            buy_truck_request = false;
            buy_manager_request = false;
        }
    }
}
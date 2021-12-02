using UnityEngine;
using System.Collections;

public class FreePlaceEnter : MonoBehaviour {

    public GameObject textField; //Connected to Text Prefab
    public GameObject building; //Connected to building Prefab
    public GameObject manager; //Connected to manager Prefab
    public GameObject truck; //Connected to truck Prefab
    public GameObject fNumber; //Connected to Floating Number Prefab
    public GameObject fTruck; //Connected to Floating Truck Art
    public GameObject buildingProcess; //Connected to Building Process Canvas Slider

    private bool build_request;
    private bool buy_manager_request;
    private bool buy_truck_request;
    private bool add_truck_request;
    private GameObject text;
    private int building_cost;

    private GameObject loading; //Instanse of loading slider
    private IEnumerator loading_waiter;  //Instanse of Coroutine

    private SFXManager sound;

    private void Start() {
        sound = FindObjectOfType<SFXManager>();

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
        if (Input.GetButtonDown("Fire1")) {

            /* Create new building */
            if (build_request && loading == null && Economics.GetMoney(building_cost, text)) {
                /* Create floating number text */
                CreateFloatingNumber(building_cost);

                Destroy(text);
                CreateNewBuilding();               
            }
            /* Hire manager */
            if (buy_manager_request) {
                /* Searching free tables */
                foreach (GameObject child in GameObject.FindGameObjectsWithTag("WorkTable")) {
                    if (child.transform.childCount == 0) {
                        if (!Economics.AddManager(text))
                            break;
                        var manager_position = new Vector3(child.transform.position.x, child.transform.position.y + 0.3f, child.transform.position.z);
                        var new_manager = Instantiate(manager, manager_position, Quaternion.Euler(Vector3.zero));
                        new_manager.transform.SetParent(child.transform);

                        /* Create floating number text */
                        CreateFloatingNumber(Economics.manager_cost_per_month);
                        break;
                    }
                }
            }

            /* Buy trucks */
            if (buy_truck_request)
                if (Economics.BuyTruck(text))
                    /* Create floating number text */
                    CreateFloatingNumber(Economics.truck_cost);
            
            /* Add truck to building */
            if (add_truck_request)
            {
                if (Economics.truck_in_inventory)
                {
                    WorldScenario.add_truck_to_world = true;
                    Economics.truck_in_inventory = false;

                    /* Create floating truck */
                    var f_truck_position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
                    Instantiate(fTruck, f_truck_position, Quaternion.Euler(Vector3.zero));
                    sound.put_effect.Play();

                } else
                    text.GetComponent<TextController>().SelectText("other", "no_truck_contract");
            }
        }

        /* Fix: loading process destroy on scene change. 
        Create a IEnumerator variable that signal about non finished loading and finish it by new coroutine */
        if (loading_waiter != null && loading == null) {
                StartCoroutine(loading_waiter);  
        }
    }

    /* Show text */
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "player_0" && loading_waiter == null)
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

    void CreateNewBuilding() {
        //Building process loading
        loading = Instantiate(buildingProcess, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
        loading.transform.SetParent(gameObject.transform);

        sound.building_process.Play();

        loading_waiter = waiter(loading);
        StartCoroutine(loading_waiter);
    }

    IEnumerator waiter(GameObject loading) {
        yield return new WaitUntil(() => loading == null); //Wait loading process
        
        //Create new building
        var new_building = Instantiate(building, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
        new_building.transform.SetParent(GameObject.Find("Buildings").transform);
        new_building.transform.tag = "Buildings";
        new_building.name = building.name;

        Destroy(gameObject);
    }

    /* Create floating number position and text */
    private void CreateFloatingNumber(int number) {
        var player = GameObject.Find("player_0");
        var f_number_position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        var clone = Instantiate(fNumber, f_number_position, Quaternion.Euler(Vector3.zero));
        clone.transform.SetParent(player.transform);
        FloatingNumbers.SetTextAndColor(number, Color.red);
        sound.money_coin.Play();
    }
}
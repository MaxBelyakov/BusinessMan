using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BuildingEnter : MonoBehaviour {

    public static Vector3 exit_building_position;
    public static GameObject enter_building_object;
    public static List<GameObject> world_objects_list;
    public static List<GameObject> world_buildings_list;
    public static List<GameObject> world_free_places_list;

    public GameObject textField; //Connected to Text Prefab
    private GameObject text;
    private bool enter_to_building = false;

    void Update() {
        /* Waiting for press Enter */
        if (Input.GetButtonDown("Submit") && enter_to_building) {
            Destroy(text);
            EnterToBuilding();
        }
    }

    /* Create text asking to enter building */
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "player_0" && gameObject.name != "main") {       
            var text_position = new Vector3(collision.transform.position.x + 1.7f, collision.transform.position.y + 0.7f, collision.transform.position.z);
            text = Instantiate(textField, text_position, Quaternion.Euler(Vector3.zero));

            text.GetComponent<TextController>().SelectText("other", "enter_to_building");
            text.transform.SetParent(collision.transform);

            enter_to_building = true;
        } else if (gameObject.name == "main") {
            EnterToBuilding();
        }
    }

    /* Hide text */
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "player_0") {
            Destroy(text);
            enter_to_building = false;
        }
    }

    /* Enter building by change scene  */ 
    void EnterToBuilding() {
        if (gameObject.name != "main") {
            //Save information about entered building
            enter_building_object = gameObject;

            /* Save enter location to transfer player position on exit */
            exit_building_position = gameObject.transform.position;

            /* Create list of active objects in the game */
            world_objects_list = new List<GameObject>();
            foreach (GameObject child in GameObject.FindGameObjectsWithTag("WorldObjects")) {
                world_objects_list.Add(child);
                child.SetActive(false);
            }

            /* Create list of active buildings in the game */
            world_buildings_list = new List<GameObject>();
            foreach (GameObject child in GameObject.FindGameObjectsWithTag("Buildings")) {
                world_buildings_list.Add(child);
                child.SetActive(false);
            }

            /* Create list of active free places in the game */
            world_free_places_list = new List<GameObject>();                
            foreach (GameObject child in GameObject.FindGameObjectsWithTag("free_place")) {
                world_free_places_list.Add(child);
                child.SetActive(false);
            }

            /* Load building objects */
            if (BuildingExit.building_objects_list != null && gameObject.name == "office") {
                foreach (GameObject item in BuildingExit.building_objects_list)
                    item.SetActive(true);
            }
        }
        else {
            foreach (GameObject item in world_objects_list)
                item.SetActive(true);
            foreach (GameObject item in world_buildings_list)
                item.SetActive(true);
            foreach (GameObject item in world_free_places_list)
                item.SetActive(true);
        }

        SceneManager.LoadScene(gameObject.name);
    }
}
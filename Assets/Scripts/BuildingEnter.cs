using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BuildingEnter : MonoBehaviour {

    public static Vector3 exit_building_position;
    public static GameObject enter_building_object;
    public static List<GameObject> world_objects_list;
    public static List<GameObject> world_buildings_list;
    public static List<GameObject> world_free_places_list;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Enter building by change scene  */
        if (collision.name == "player_0")
        {
            if (gameObject.name != "main")
            {
                //Save information about entered building
                enter_building_object = gameObject;

                /* Save enter location to transfer player position on exit */
                exit_building_position = gameObject.transform.position;

                /* Create list of active objects in the game */
                world_objects_list = new List<GameObject>();
                foreach (GameObject child in GameObject.FindGameObjectsWithTag("WorldObjects"))
                {
                    world_objects_list.Add(child);
                    child.SetActive(false);
                }

                /* Create list of active buildings in the game */
                world_buildings_list = new List<GameObject>();
                foreach (GameObject child in GameObject.FindGameObjectsWithTag("Buildings"))
                {
                    world_buildings_list.Add(child);
                    child.SetActive(false);
                }

                /* Create list of active free places in the game */
                world_free_places_list = new List<GameObject>();
                foreach (GameObject child in GameObject.FindGameObjectsWithTag("free_place"))
                {
                    world_free_places_list.Add(child);
                    child.SetActive(false);
                }
            }
            else
            {
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
}
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BuildingEnter : MonoBehaviour {

    public static Vector3 exit_building_position;
    public static List<GameObject> world_objects_list;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Enter building by change scene  */
        if (collision.name == "player_0")
        {
            if (gameObject.name != "main")
            {
                /* Save enter location to transfer player position on exit */
                exit_building_position = gameObject.transform.position;

                /* Create list of active objects in the game */
                world_objects_list = new List<GameObject>();
                foreach (GameObject child in GameObject.FindGameObjectsWithTag("WorldObjects"))
                {
                    world_objects_list.Add(child);
                    child.SetActive(false);
                }
            }
            else if (world_objects_list != null)
            {
                foreach (GameObject item in world_objects_list)
                    item.SetActive(true);
            }

            SceneManager.LoadScene(gameObject.name);
        }     
    }
}
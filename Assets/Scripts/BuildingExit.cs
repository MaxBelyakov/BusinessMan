/*
Create list of all active objects in the building (objects must have tag 'BuildingObjects')
*/

using UnityEngine;
using System.Collections.Generic;

public class BuildingExit : MonoBehaviour {

    public static List<GameObject> building_objects_list;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Exit building by change scene  */
        if (collision.name == "player_0" && gameObject.name == "main") {
                
			/* Create list of active objects in the building */
			building_objects_list = new List<GameObject>();
			foreach (GameObject child in GameObject.FindGameObjectsWithTag("BuildingObjects"))
			{
				building_objects_list.Add(child);
				child.SetActive(false);
			}
		}
    }
}
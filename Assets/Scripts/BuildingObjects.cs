/*
Save building objects when move between scenes and delete duplicates
*/

using UnityEngine;

public class BuildingObjects : MonoBehaviour {

	private static bool buildingObjectsLoaded;

    void Start () {
        if (!buildingObjectsLoaded) {
            buildingObjectsLoaded = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
	}
}
using UnityEngine;

public class WorldScenario : MonoBehaviour {

    public GameObject truck1;
    private static bool scenarioLoaded;

    void Start () {
        /* Add WorldObjects once on start, if player moving between scenes - destroy duplicates */
        if (!scenarioLoaded)
        {
            scenarioLoaded = true;
            TruckMoving.Point_A = GameObject.Find("office");
            TruckMoving.Point_B = GameObject.Find("lumber");
            GameObject item = Instantiate(truck1, new Vector3(0, 0, 0), Quaternion.identity);
            item.transform.SetParent(gameObject.transform);
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);        
    }
}

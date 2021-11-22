using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/* Police car behavior */

public class PoliceCar : MonoBehaviour {

    private Rigidbody2D rb;
    private List<GameObject> world_objects_list_for_police;
    private GameObject Police_point_A;
    private GameObject Police_point_B; //Truck target 

    private bool get_target = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        PoliceWaiting();
    }

    /* Moving for target */
    private void Update() {
        if (get_target)
            WorldScenario.MovingToTarget(Police_point_B.transform.position, rb);
    }

    /* Waiting for target */
    void PoliceWaiting() {
        int waiting_at_office = Random.Range(1, 1);
        Invoke("PoliceWorking", waiting_at_office);
    }

    /* Looking for target */
    void PoliceWorking() {
        world_objects_list_for_police = new List<GameObject>();
        foreach (GameObject child in GameObject.FindGameObjectsWithTag("WorldObjects"))
        {
            if (child.tag != "Police")
                world_objects_list_for_police.Add(child);
        }

        Police_point_B = world_objects_list_for_police[0]; //Add there a random choice
        get_target = true;
    }

    /* Catch target by box collider connection */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (get_target && (collision.name == Police_point_B.name))
        {
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            // Turn on police lights animation
        }
    }
}
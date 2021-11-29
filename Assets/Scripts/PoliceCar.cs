using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

/* Police car behavior */

public class PoliceCar : MonoBehaviour {

    private Rigidbody2D rb;
    private Rigidbody2D caught_truck;
    private List<GameObject> world_objects_list_for_police;
    private GameObject Police_point_A;
    private GameObject Police_point_B; //Truck target
    public GameObject fNumber; //Connected to Floating Numbers canvas

    private bool get_target = false;
    private bool catch_target = false;
    private bool return_to_office = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Police_point_A = transform.parent.gameObject;

        PoliceWaiting();
    }

    /* Moving for target */
    private void Update() {
        if (get_target)
            WorldScenario.MovingToTarget(Police_point_B.transform.position, rb);
    }

    /* Waiting for target */
    void PoliceWaiting() {
        int waiting_at_office = Random.Range(5, 10);
        Invoke("PoliceWorking", waiting_at_office);
    }

    /* Looking for target */
    void PoliceWorking() {
        if (SceneManager.GetActiveScene().name == "main")
        {
            world_objects_list_for_police = new List<GameObject>();
            foreach (GameObject child in GameObject.FindGameObjectsWithTag("WorldObjects"))
            {
                if (child.transform.parent.name != "policeStation")
                    world_objects_list_for_police.Add(child);
            }
            
            Police_point_B = world_objects_list_for_police[Random.Range(0, world_objects_list_for_police.Count)];

            get_target = true;
        } else
        {
            PoliceWaiting(); //BugFix: to avoid situation when player move to another scene while police waiting
        }
    }

    /* Catch target by box collider connection */
    private void OnTriggerEnter2D(Collider2D collision) {
        //Connect with truck by ID
        if (get_target && !return_to_office && (collision.gameObject.GetInstanceID() == Police_point_B.GetInstanceID()))
        {
            caught_truck = collision.GetComponent<Rigidbody2D>();
            caught_truck.constraints = RigidbodyConstraints2D.FreezeAll;
            catch_target = true;
            // Turn on police lights animation
        }
        //Connect with money
        if (catch_target && collision.name == "money") {

            /* Create floating numbers text */
            var player = GameObject.Find("player_0");
            var f_number_position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
            Instantiate(fNumber, f_number_position, Quaternion.Euler(Vector3.zero));

            if (Economics.GetMoney(Economics.pay_to_police, null)) {
                caught_truck.constraints = RigidbodyConstraints2D.None;
                caught_truck.constraints = RigidbodyConstraints2D.FreezeRotation;
                catch_target = false;

                FloatingNumbers.SetTextAndColor(Economics.pay_to_police, Color.red);

                ReturnToOffice();
                // Turn off police lights animation
            } else
                //No money
                FloatingNumbers.SetTextAndColor(Economics.pay_to_police, Color.red, true);
        }
        //Connect with police station
        if (return_to_office && collision.name == "policeStation")
        {
            get_target = false;
            return_to_office = false;
            rb.velocity = Vector2.zero;
            PoliceWaiting();
        }
    }

    /* Returning to police station */
    void ReturnToOffice() {
        return_to_office = true;
        Police_point_B = Police_point_A;
        get_target = true;
    }
}
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/* Collect common functions and gamestart scenario */

public class WorldScenario : MonoBehaviour {

    public GameObject truck;
    private static bool scenarioLoaded;

    private static float Step_x;
    private static float Step_y;
    private static bool FaceRight; //Car face durection

    public static bool add_truck_to_world = false;

    void Start () {
        if (!scenarioLoaded)
        {
            scenarioLoaded = true;

            /* Add money to buy scenario objects */
            Economics.AddMoney(120000);

            /* Add first manager to the office */
            Economics.AddManager(null);

            /* Add first truck to the world */
            Economics.BuyTruck(null);
            Economics.truck_in_inventory = false;
            AddTruckFromInventory(GameObject.Find("lumber"));

            DontDestroyOnLoad(gameObject);
        } else
            Destroy(gameObject);
    }

    private void Update()
    {
        /* Check the player add truck to the world inside the building */
        if (SceneManager.GetActiveScene().name == "main" && add_truck_to_world)
        {
            AddTruckFromInventory(BuildingEnter.enter_building_object);
            add_truck_to_world = false;
        }  
    }

    /* Transport moving function */
    public static void MovingToTarget(Vector3 target, Rigidbody2D rb)
    {
        if (Math.Round(rb.position.x, 1) < Math.Round(target.x, 1))
        {
            Step_x = 1f;
            FaceRight = true;
        }
        else if (Math.Round(rb.position.x, 1) > Math.Round(target.x, 1))
        {
            Step_x = -1f;
            FaceRight = false;
        }
        else
            Step_x = 0f;

        if (Math.Round(rb.position.y, 1) < Math.Round(target.y, 1))
            Step_y = 1f;
        else if (Math.Round(rb.position.y, 1) > Math.Round(target.y, 1))
            Step_y = -1f;
        else
            Step_y = 0f;

        /* Turn the face by moving direction */
        Vector3 FaceTarget = rb.transform.rotation.eulerAngles;
        if (!FaceRight)
            rb.transform.rotation = Quaternion.Euler(FaceTarget.x, 180, FaceTarget.z);
        else
            rb.transform.rotation = Quaternion.Euler(FaceTarget.x, 0, FaceTarget.z);

        rb.velocity = new Vector2(Step_x, Step_y);
    }

    /* Add truck from inventory and connect it to A and B points */
    private void AddTruckFromInventory(GameObject point_B)
    {
        GameObject item = Instantiate(truck, new Vector3(0, 0, 0), Quaternion.identity);
        item.transform.SetParent(point_B.transform);
    }   
}
using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class PoliceStation : MonoBehaviour {

    public GameObject police;
    private Rigidbody2D rb;
    private Vector3 car_position;
    private int waiting_at_office;
    private List<GameObject> world_objects_list_for_police;

    private GameObject Police_point_A;
    private GameObject Police_point_B;

    private bool get_target = false;

    private float Step_x;
    private float Step_y;
    private bool FaceRight; //Truck face durection
    private Vector3 target; //Which way to move, A or B

    void Start () {
        car_position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);
        var police_car = Instantiate(police, car_position, Quaternion.identity);
        police_car.transform.SetParent(GameObject.Find("WorldObjects").transform);
        rb = police_car.GetComponent<Rigidbody2D>();

        Police_point_A = gameObject;

        PoliceWaiting();
	}

    private void Update() {
        if (get_target)
        {
            target = Police_point_B.transform.position;
            MovingToTarget();
        }
        
    }

    void PoliceWaiting() {
        waiting_at_office = Random.Range(1,1);
        Invoke("PoliceWorking", waiting_at_office);
    }

    void PoliceWorking() {
        world_objects_list_for_police = new List<GameObject>();
        foreach (GameObject child in GameObject.FindGameObjectsWithTag("WorldObjects"))
        {
            if (child.tag != "Police")
                world_objects_list_for_police.Add(child);
        }

        Police_point_B = world_objects_list_for_police[0];
        get_target = true;

        
    }

    /* Moving */
    void MovingToTarget()
    {
        if (Math.Round(rb.transform.position.x, 1) < Math.Round(target.x, 1))
        {
            Step_x = 1f;
            FaceRight = true;
        }
        else if (Math.Round(rb.transform.position.x, 1) > Math.Round(target.x, 1))
        {
            Step_x = -1f;
            FaceRight = false;
        }
        else
            Step_x = 0f;

        if (Math.Round(rb.transform.position.y, 1) < Math.Round(target.y, 1))
            Step_y = 1f;
        else if (Math.Round(rb.transform.position.y, 1) > Math.Round(target.y, 1))
            Step_y = -1f;
        else
            Step_y = 0f;

        //Turn the police face by moving direction
        Vector3 FaceTarget = rb.transform.rotation.eulerAngles;
        if (!FaceRight)
            rb.transform.rotation = Quaternion.Euler(FaceTarget.x, 180, FaceTarget.z);
        else
            rb.transform.rotation = Quaternion.Euler(FaceTarget.x, 0, FaceTarget.z);

        rb.velocity = new Vector2(Step_x, Step_y);
    }
}
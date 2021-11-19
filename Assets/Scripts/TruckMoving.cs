using System.Collections;
using UnityEngine;
using System;

/* Need to use Math.Round function to connect truck and checkpoints */

public class TruckMoving : MonoBehaviour {

    public static GameObject Point_A; //Where we request the truck (Sender)
    public static GameObject Point_B; //Where we will send the truck (Reciever)
    private Vector3 Point_A_position; //Sender truck point
    private Vector3 Point_B_position; //Reciever truck point
    private Vector3 target; //Which way to move, A or B

    private Rigidbody2D rb;
    private bool FaceRight; //Truck face durection
    private bool Loading = false; //Wait for loading truck

    private float Step_x;
    private float Step_y;

    void Start () {
        rb = GetComponent<Rigidbody2D>();

        Point_A_position = new Vector3(Point_A.transform.position.x + 1f, Point_A.transform.position.y, Point_A.transform.position.z);
        Point_B_position = new Vector3(Point_B.transform.position.x - 1f, Point_B.transform.position.y, Point_B.transform.position.z);

        //Temporary truck creates on Point_A_position, next is to create by events
        gameObject.transform.position = Point_A_position;

        FindTheTarget();
    }
	
	void Update () {
        /* Check to stay on target point */
        if (!Loading && Math.Round(gameObject.transform.position.x, 1) == Math.Round(target.x, 1) && Math.Round(gameObject.transform.position.y, 1) == Math.Round(target.y, 1))
        {
            Loading = true;
            Invoke("TruckLoading", 3f);
        }
        else
            MovingToTarget();     
    }

    /* Truck waiting on target */
    void TruckLoading ()
    {
        Loading = false;
        FindTheTarget();
    }

    /* Which way moving, to A or to B? */
    void FindTheTarget() {
        if (Math.Round(gameObject.transform.position.x, 1) == Math.Round(Point_A_position.x, 1) && Math.Round(gameObject.transform.position.y, 1) == Math.Round(Point_A_position.y, 1))
            target = Point_B_position;
        else if (Math.Round(gameObject.transform.position.x, 1) == Math.Round(Point_B_position.x, 1) && Math.Round(gameObject.transform.position.y, 1) == Math.Round(Point_B_position.y, 1))
            target = Point_A_position;
    }

    /* Moving */
    void MovingToTarget() {
        if (Math.Round(gameObject.transform.position.x, 1) < Math.Round(target.x, 1))
        {
            Step_x = 1f;
            FaceRight = true;
        }
        else if (Math.Round(gameObject.transform.position.x, 1) > Math.Round(target.x, 1))
        {
            Step_x = -1f;
            FaceRight = false;
        }
        else
            Step_x = 0f;

        if (Math.Round(gameObject.transform.position.y, 1) < Math.Round(target.y, 1))
            Step_y = 1f;
        else if (Math.Round(gameObject.transform.position.y, 1) > Math.Round(target.y, 1))
            Step_y = -1f;
        else
            Step_y = 0f;

        //Turn the truck face by moving direction
        Vector3 FaceTarget = transform.rotation.eulerAngles;
        if (!FaceRight)
            transform.rotation = Quaternion.Euler(FaceTarget.x, 180, FaceTarget.z);
        else
            transform.rotation = Quaternion.Euler(FaceTarget.x, 0, FaceTarget.z);

        rb.velocity = new Vector2(Step_x, Step_y);
    }
}
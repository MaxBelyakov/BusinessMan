using UnityEngine;
using System;

/* Collect common functions and gamestart scenario */

public class WorldScenario : MonoBehaviour {

    public GameObject truck1;
    private static bool scenarioLoaded;

    private static float Step_x;
    private static float Step_y;
    private static bool FaceRight; //Car face durection

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
}
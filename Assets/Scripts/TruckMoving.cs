using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckMoving : MonoBehaviour {

    private GameObject Point_A; //Where we request the truck (Sender)
    private GameObject Point_B; //Where we will send the truck (Reciever)
    private float Point_B_id; //Get uniq id number of Reciever
    private GameObject target; //Define which way to go
    public GameObject fNumber; //Connected to Floating Numbers canvas

    private Rigidbody2D rb;
    private bool Loading = false; //Wait for loading truck

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        Point_A = GameObject.Find("office");
        Point_B = transform.parent.gameObject;

        //Creates truck on Point_A position and select target
        gameObject.transform.position = new Vector2(Point_A.transform.position.x, Point_A.transform.position.y - 1f);
        target = Point_B;
        Point_B_id = Point_B.GetInstanceID();
    }
	
	void Update () {
        /* Moving */
        if (!Loading)
            WorldScenario.MovingToTarget(target.transform.position, rb);
        else
            rb.velocity = new Vector2(0f, 0f);
    }

    /* Truck loading and change target */
    void TruckLoading () {
        target = Point_A;
        Loading = false;
    }

    /* Truck unloading and change target */
    void TruckUnloading () {
        target = Point_B;
        Economics.AddMoney(Economics.income_truck);

        /* Create floating numbers text */
        if (SceneManager.GetActiveScene().name == "main") {
            var f_number_position = new Vector2(rb.position.x, rb.position.y + 0.5f);
            Instantiate(fNumber, f_number_position, Quaternion.Euler(Vector3.zero));
            FloatingNumbers.SetTextAndColor(Economics.income_truck, Color.green);
        }

        Loading = false;
    }

    /* Checks which point truck came */
    void OnTriggerEnter2D(Collider2D collision) {
        if (target == Point_B && collision.gameObject.GetInstanceID() == Point_B_id) {
            Loading = true;
            Invoke("TruckLoading", 3f);
        }
        if (target == Point_A && collision.name == Point_A.name) {
            Loading = true;
            Invoke("TruckUnloading", 3f);
        }
    }
}
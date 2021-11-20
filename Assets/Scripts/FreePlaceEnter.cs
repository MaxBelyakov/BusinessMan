using UnityEngine;

public class FreePlaceEnter : MonoBehaviour {

    public GameObject textField; //Connected to Text Prefab
    public GameObject building; //Connected to building Prefab
    private bool build_request = false;
    private GameObject text;

    private void Update() {
        /* Create new building insead free place */
        if (Input.GetButtonDown("Submit") && build_request)
        {
            var new_building = Instantiate(building, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            new_building.transform.SetParent(GameObject.Find("Buildings").transform);
            Destroy(gameObject);
        }
    }

    /* Show text */
    private void OnTriggerEnter2D(Collider2D collision) {
        var text_position = new Vector3(collision.transform.position.x + 1.7f, collision.transform.position.y + 0.7f, collision.transform.position.z);
        text = Instantiate(textField, text_position, Quaternion.Euler(Vector3.zero));

        text.GetComponent<TextController>().SelectText("buy", gameObject.name);
        text.transform.SetParent(collision.transform);

        build_request = true;
    }

    /* Hide text */
    private void OnTriggerExit2D(Collider2D collision) {
        Destroy(text);
        build_request = false;
    }
}
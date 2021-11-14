using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingEnter : MonoBehaviour {

    public static Vector3 exit_building_position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Enter building by change scene  */
        if (collision.name == "player_0")
        {
            /* Save enter location to transfer player position on exit */
            if (gameObject.name != "main")
                exit_building_position = gameObject.transform.position;

            SceneManager.LoadScene(gameObject.name);
        }     
    }
}
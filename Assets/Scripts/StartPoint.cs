/* */
/* Start point position have to be placed on the map of each scene */
/* */

using UnityEngine.SceneManagement;
using UnityEngine;

public class StartPoint : MonoBehaviour
{

    private player_controller thePlayer;
    private CameraController theCamera;

    void Start()
    {
        thePlayer = FindObjectOfType<player_controller>();
        theCamera = FindObjectOfType<CameraController>();

        /* Move player and camera to start point position or to the enter building position */
        if (SceneManager.GetActiveScene().name != "main")
        {
            thePlayer.transform.position = transform.position;
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
        else
        {
            thePlayer.transform.position = new Vector3(BuildingEnter.exit_building_position.x + 1f, BuildingEnter.exit_building_position.y, thePlayer.transform.position.z);
            theCamera.transform.position = new Vector3(BuildingEnter.exit_building_position.x + 1f, BuildingEnter.exit_building_position.y, theCamera.transform.position.z);
        }
    }
}
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
            var position = BuildingEnter.exit_building_position;
            thePlayer.transform.position = new Vector3(position.x, position.y - 1f, thePlayer.transform.position.z);
            theCamera.transform.position = new Vector3(position.x, position.y - 1f, theCamera.transform.position.z);
        }
    }
}
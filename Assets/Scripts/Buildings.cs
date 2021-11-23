using UnityEngine;

/* Buildings behavior */

public class Buildings : MonoBehaviour {

    private static bool buildingsLoaded;

    void Start () {
        /* Save buildings when move between scenes and delete duplicates */
        if (!buildingsLoaded)
        {
            buildingsLoaded = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}

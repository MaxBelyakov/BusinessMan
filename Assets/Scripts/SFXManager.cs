/*
Control Audio files
*/

using UnityEngine;

public class SFXManager : MonoBehaviour {

	public AudioSource police_siren;
	public AudioSource money_coin;
	public AudioSource money_earn;
	public AudioSource building_process;
	public AudioSource put_effect;

	public static bool soundExists;

	void Start () {
		/* Sound effects will transfer between scenes, duplicates will destroy */
        if (!soundExists)
        {
            soundExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
	}
}
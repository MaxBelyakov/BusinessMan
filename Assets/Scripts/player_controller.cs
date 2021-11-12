using UnityEngine;

public class player_controller : MonoBehaviour {

    public float movespeed = 3;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update () {

        /* Moving up and down */
		if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * movespeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * movespeed * Time.deltaTime, 0f));
        }

        /* Transfer parametrs to Animator */
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

    }
}
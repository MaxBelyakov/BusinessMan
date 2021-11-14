using UnityEngine;

public class player_controller : MonoBehaviour {

    public float movespeed = 3;
    private Animator anim;
    private Rigidbody2D rb;

    private static bool playerExists;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        /* First player will transfer between scenes, duplicates will destroy */
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Update () {

        /* Moving up and down */
		if (Input.GetAxisRaw("Horizontal") != 0)
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movespeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0f, rb.velocity.y);

        if (Input.GetAxisRaw("Vertical") != 0)
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * movespeed);
        else
            rb.velocity = new Vector2(rb.velocity.x, 0f);

        /* Transfer parametrs to Animator */
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

    }
}
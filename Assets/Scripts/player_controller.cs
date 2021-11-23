using UnityEngine;

public class player_controller : MonoBehaviour {

    public float movespeed = 3;
    private Animator anim;
    private Rigidbody2D rb;

    private static bool playerExists;

    private float move_x;
    private float move_y;

    private bool give_money = false;
    public float giveMoneyTime; //Speed of give money
    private float give_money_counter;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        transform.Find("money").gameObject.SetActive(false); //Hide money

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
		if (Input.GetAxisRaw("Horizontal") != 0 && !give_money)
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movespeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0f, rb.velocity.y);

        if (Input.GetAxisRaw("Vertical") != 0 && !give_money)
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * movespeed);
        else
            rb.velocity = new Vector2(rb.velocity.x, 0f);

        move_x = Input.GetAxisRaw("Horizontal");
        move_y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            give_money_counter = giveMoneyTime;
            transform.Find("money").gameObject.SetActive(true);
            move_x = 0;
            move_y = 0;
            give_money = true;
        }

        if (give_money_counter > 0)
            give_money_counter -= Time.deltaTime;
        else
        {
            transform.Find("money").gameObject.SetActive(false);
            give_money = false;
        }

        /* Transfer parametrs to Animator */
        anim.SetFloat("MoveX", move_x);
        anim.SetFloat("MoveY", move_y);
        anim.SetBool("GiveMoney", give_money);
    }
}
using UnityEngine;

public class Economics : MonoBehaviour {

    private static int manager_cost_per_month = 10000;
    private int office_cost_per_month = 50000;
    private static int truck_cost = 50000;

    public static int money = 0;
    public static int costs = 0;
    public static int trucks = 0;
    public static int managers = 0;
    public static int month = 1;
    public static int day = 1;
    public static int time = 0;
    private float game_time = 0;
    public float game_speed = 2.8f; //Time change speed
    private static int manager_productivity = 3; //How many trucks can manager control
    public static int pay_to_police = 500;
    public static int income_truck = 500000;

    public static int lumber_cost = 100000;
    public static int mine_cost = 200000;
    public static int blacksmith_cost = 150000;

    public static bool truck_in_inventory = false; //When buy truck it goes to inventory

    private void Update() {
        //Costs per month calculating
        costs = managers * manager_cost_per_month + office_cost_per_month;

        /* Time counter */
        game_time += Time.deltaTime * game_speed;
        time = Mathf.RoundToInt(game_time);
        if (time >= 24)
        {
            time = 0;
            game_time = 0;
            day += 1;
            if (day > 30)
            {
                day = 1;
                month += 1;
                
                // Costs per month pay
                if (money - costs >= 0)
                {
                    money = money - costs;
                } else
                {
                    GameOver();
                }
            }
        }
    }

    /* Add manager. Return true/false */
    public static bool AddManager(GameObject text) {
        if ((money - manager_cost_per_month) >= 0)
        {
            money = money - manager_cost_per_month;
            managers += 1;
            return true;
        } else
        {
            text.GetComponent<TextController>().SelectText("other", "no_money");
            return false;
        }
    }

    /* Buy truck. Return true/false */
    public static bool BuyTruck(GameObject text)
    {
        //Player already buy truck
        if (truck_in_inventory)
        {
            text.GetComponent<TextController>().SelectText("other", "truck_in_inventory");
            return false;
        }
        //Not enought managers
        if (trucks >= managers * manager_productivity)
        {
            text.GetComponent<TextController>().SelectText("other", "no_managers");
            return false;
        }
        //Buy truck
        if ((money - truck_cost) >= 0)
        {
            money = money - truck_cost;
            trucks += 1;
            truck_in_inventory = true;
            return true;
        }
        else
        {
            text.GetComponent<TextController>().SelectText("other", "no_money");
            return false;
        }
    }

    /* Add money to the game */
    public static void AddMoney(int amount)
    {
        money = money + amount;
    }

    /* Get money from the game */
    public static bool GetMoney(int amount, GameObject text)
    {
        if (money - amount >= 0) {
            money = money - amount;
            return true;
        } else {
            text.GetComponent<TextController>().SelectText("other", "no_money");
            return false;
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver");
    }
}

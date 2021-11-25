﻿using UnityEngine.UI;
using UnityEngine;

public class StatusPanel : MonoBehaviour {

    public Text moneyText;
    public Text costsText;
    public Text trucksText;
    public Text managersText;
    public Text daysText;
    private string time_zero;
    public GameObject BuyTruck;

    private static bool panelExists;

    void Start () {
        BuyTruck.SetActive(false);

        /* Panel transfer between scenes, duplicates will destroy */
        if (!panelExists)
        {
            panelExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Update()
    {
        moneyText.text = "Money: " + Economics.money;
        costsText.text = "Costs: " + Economics.costs + " per " + "month";
        trucksText.text = "Trucks: " + Economics.trucks;
        managersText.text = "Managers: " + Economics.managers;

        /* Add 0 before time value to show format 00:00 */
        if (Economics.time < 10)
            time_zero = "0";
        else
            time_zero = "";
        daysText.text = "Month: " + Economics.month + ", day: " + Economics.day + "\n" + "Time: " + time_zero + Economics.time + ":00";

        /* Show truck at the players status panel */
        if (Economics.truck_in_inventory)
            BuyTruck.SetActive(true);
        else
            BuyTruck.SetActive(false);
    }
}
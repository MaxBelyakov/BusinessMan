using UnityEngine.UI;
using UnityEngine;

public class StatusPanel : MonoBehaviour {

    public Text moneyText;
    public Text costsText;
    public Text trucksText;
    public Text managersText;

    private static bool panelExists;

    void Start () {
        moneyText.text = "Money: " + Economics.money;
        costsText.text = "Costs: " + Economics.costs + " per " + "month";
        trucksText.text = "Trucks: " + Economics.trucks;
        managersText.text = "Managers: " + Economics.managers;

        /* Panel transfer between scenes, duplicates will destroy */
        if (!panelExists)
        {
            panelExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }
}

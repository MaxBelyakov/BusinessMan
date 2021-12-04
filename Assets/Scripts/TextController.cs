using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text displayText; //Connected to Text field

    /* Choose which text to show. Depends of incomming request parametrs */
    public void SelectText(string request, string name) {
        if (request == "buy") {
            if (name == "wood")
                displayText.text = "Wood plant" + "\n" + "Build price: $5.000" + "\n" + "Press 'space' to build";
            else if (name == "mountain")
                displayText.text = "Mine" + "\n" + "Build price: $10.000" + "\n" + "Press 'space' to build";
            else if (name == "rocks")
                displayText.text = "Blacksmith" + "\n" + "Build price: $7.000" + "\n" + "Press 'space' to build";
            else if (name == "buyManagerCell")
                displayText.text = "Hire new manager" + "\n" + "Costs: $10.000 per month" + "\n" + "Productivity: control 3 trucks" + "\n" + "Press 'space' to hire";
            else if (name == "buyTruckCell")
                displayText.text = "Buy new truck" + "\n" + "Price: $5.000" + "\n" + "Press 'space' to buy";
            else if (name == "addTruckCell")
                displayText.text = "Press 'space' to add truck";
        }
        else if (request == "other") {
            displayText.color = Color.red;
            if (name == "no_truck_contract")
                displayText.text = "There is no truck contract in your inventory. Buy truck in the office";
            else if (name == "no_money")
                displayText.text = "Not enought money";
            else if (name == "no_managers")
                displayText.text = "You have no manager to control new truck. Hire new one in office";
            else if (name == "truck_in_inventory")
                displayText.text = "There is a truck in your inventory. Select a building to connect it";  
            else if (name == "enter_to_building") {
                displayText.text = "To enter the building press 'enter'";
                displayText.color = Color.white;
            }
        }
    }
}

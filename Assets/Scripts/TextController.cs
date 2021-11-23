using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text displayText; //Connected to Text field

    /* Choose which text to show. Depends of incomming request parametrs */
    public void SelectText(string request, string name) {
        if (request == "buy")
        {
            if (name == "wood")
            {
                displayText.text = "Wood plant" + "\n" + "Resourses: 100.000" + "\n" + "Build price: 5.000" + "\n" + "Press 'space' to build";
            }
            else if (name == "mountain")
            {
                displayText.text = "Mine" + "\n" + "Resourses: 200.000" + "\n" + "Build price: 10.000" + "\n" + "Press 'space' to build";
            }
            else if (name == "rocks")
            {
                displayText.text = "Blacksmith" + "\n" + "Resourses: 150.000" + "\n" + "Build price: 7.000" + "\n" + "Press 'space' to build";
            }
        }
    }
}

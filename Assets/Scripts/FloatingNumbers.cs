/*
Create floating numbers that move up and hides
*/

using UnityEngine;
using UnityEngine.UI;
using System;

public class FloatingNumbers : MonoBehaviour {

	public Text floatingNumber;
	private float moveSpeed = 1;
	public static string fNumberText = "";
	public static Color fNumberColor = Color.green;

	void Start() {
		Invoke("DestroyFloatingNumber", 1);
	}

	void Update() {
		floatingNumber.text = fNumberText;
		floatingNumber.color = fNumberColor;
		floatingNumber.transform.rotation = Quaternion.Euler(0, 0, 0);
		transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
	}

	public static void SetTextAndColor(int number, Color color, bool no_money_text = false) {
		if (!no_money_text)
			fNumberText = String.Format("{0:C0}", number);
		else
			fNumberText = "Not enought money";
		fNumberColor = color;
	}

	void DestroyFloatingNumber() {
		Destroy(gameObject);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddBet : MonoBehaviour
{   
    public static int number = 0;

    [SerializeField]
    private TextMeshProUGUI betText;

    private int lines = 3;

    private void OnMouseDown(){
        number = number + 1;

        int newBet = number * lines;

        betText.text = newBet.ToString();
    }
}

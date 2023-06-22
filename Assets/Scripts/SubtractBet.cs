using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtractBet : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI betText;

    private int lines = 3;

    //subtracts the total bet when the minus sign is clicked
    private void OnMouseDown(){
        AddBet.number = AddBet.number - 1;

        //error checking for when total bet becomes less than 0
        if(AddBet.number < 0){
            AddBet.number = 0;
        }

        //subtracts by the number of lines
        int newBet = AddBet.number * lines;
        
        betText.text = newBet.ToString();
    }
}

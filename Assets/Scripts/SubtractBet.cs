using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtractBet : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI betText;

    private int lines = 20;

    private void OnMouseDown(){
        AddBet.number = AddBet.number - 1;

        if(AddBet.number < 0){
            AddBet.number = 0;
        }

        int newBet = AddBet.number * lines;
        
        betText.text = newBet.ToString();
    }
}

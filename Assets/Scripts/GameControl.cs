using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static event Action SpinPressed = delegate { };

    [SerializeField]
    private TextMeshProUGUI coinsText;

    [SerializeField]
    private TextMeshProUGUI betText;

    [SerializeField]
    private TextMeshProUGUI winText;

    [SerializeField]
    private Row[] rows;

    private bool resultsChecked = false;

    void Update(){
        if(!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped || !rows[3].rowStopped || !rows[4].rowStopped){
            resultsChecked = false;
        }

        if(rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped && !resultsChecked){
            CheckResults();
        }
    }

    private void OnMouseDown(){
        print("PRESSED");
        if(rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped){
            if(int.Parse(coinsText.text) >= int.Parse(betText.text) && int.Parse(betText.text) != 0){
                StartCoroutine("Spin");

                int newCoins = int.Parse(coinsText.text) - int.Parse(betText.text);
                coinsText.text = newCoins.ToString();
            }
        }
    }

    private IEnumerator Spin(){
        SpinPressed();

        yield return new WaitForSeconds(0.1f);
    }

    private void CheckResults(){
        // private string[] firstSlotValues = new string[];
        // private string[] secondSlotValues = new string[];
        // private string[] thirdSlotValues = new string[];

        // for(int i=0; i<5; i++){
        //     firstSlotValues.Append(rows[0].firstSlotValues).ToArray(firstSlotValues);
        //     secondSlotValues.Append(rows[1].secondSlotValues).ToArray(secondSlotValues);
        //     thirdSlotValues.Append(rows[2].thirdSlotValues).ToArray(thirdSlotValues);
        // }

        // for(i=0; i<5; i++){
        //     count = firstSlotValues.Count(c => c == firstSlotValues[i]);

        //     if(count >= 3 && count <= 5){
        //         int newWin = int.Parse(winText.text) + 1;

        //         winText.text = newWin.ToString();
        //     }
        // }

        // for(i=0; i<5; i++){
        //     count = secondSlotValues.Count(c => c == secondSlotValues[i]);

        //     if(count >= 3 && count <= 5){
        //         newWin = int.Parse(winText.text) + 1;

        //         winText.text = newWin.ToString();
        //     }
        // }

        // for(i=0; i<5; i++){
        //     count = thirdSlotValues.Count(c => c == thirdSlotValues[i]);

        //     if(count >= 3 && count <= 5){
        //         newWin = int.Parse(winText.text) + 1;

        //         winText.text = newWin.ToString();
        //     }
        // }

        resultsChecked = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static event Action SpinPressed = delegate { };
    public static bool showResults = false;

    [SerializeField]
    private TextMeshProUGUI coinsText;

    [SerializeField]
    private TextMeshProUGUI betText;

    [SerializeField]
    private TextMeshProUGUI winText;

    [SerializeField]
    private Row[] rows;

    void Update(){
        if(rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped && showResults){
            CheckResults();
        }
    }

    private void OnMouseDown(){
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
        string[] firstSlotValues = new string[5];
        string[] secondSlotValues = new string[5];
        string[] thirdSlotValues = new string[5];
        
        int newWin;
        int count;

        for(int i=0; i<5; i++){
            firstSlotValues.Append(rows[0].firstStoppedSlot).ToArray();
            secondSlotValues.Append(rows[1].secondStoppedSlot).ToArray();
            thirdSlotValues.Append(rows[2].thirdStoppedSlot).ToArray();
        }

        for(int i=0; i<5; i++){
            count = firstSlotValues.Count(c => c == firstSlotValues[i]);

            print(firstSlotValues[i] + " " + count);

            if(count >= 2 && count <= 5){
                newWin = int.Parse(winText.text) + 1;

                winText.text = newWin.ToString();
            }
        }

        // for(int i=0; i<5; i++){
        //     count = secondSlotValues.Count(c => c == secondSlotValues[i]);

        //     if(count >= 2 && count <= 5){
        //         newWin = int.Parse(winText.text) + 1;

        //         winText.text = newWin.ToString();
        //     }
        // }

        // for(int i=0; i<5; i++){
        //     count = thirdSlotValues.Count(c => c == thirdSlotValues[i]);

        //     if(count >= 2 && count <= 5){
        //         newWin = int.Parse(winText.text) + 1;

        //         winText.text = newWin.ToString();
        //     }
        // }

        showResults = false;
    }
}

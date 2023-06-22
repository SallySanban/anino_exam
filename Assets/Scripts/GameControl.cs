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
        int index = 0;
        while(index < 3){
            List<string> slotValues = new List<string>();

            int newWin;
            int count;

            for(int i=0; i<5; i++){
                if(index == 0){
                    slotValues.Add(rows[i].firstStoppedSlot);
                }
                else if(index == 1){
                    slotValues.Add(rows[i].secondStoppedSlot);
                }
                else if(index == 2){
                    slotValues.Add(rows[i].thirdStoppedSlot);
                }
            }

            List <string> distinctSlotValues = slotValues.Distinct().ToList();

            IDictionary<string, int> countSlot = new Dictionary<string, int>();

            for(int i=0; i<distinctSlotValues.Count; i++){
                count = slotValues.Where(x => x != null && x.Equals(distinctSlotValues[i])).Count();
                countSlot.Add(distinctSlotValues[i], count);
            }

            foreach(KeyValuePair<string, int> kvp in countSlot){
                if(countSlot[kvp.Key] == 3){
                    newWin = int.Parse(winText.text) + 1;

                    winText.text = newWin.ToString();
                }
                else if(countSlot[kvp.Key] == 4){
                    newWin = int.Parse(winText.text) + 5;

                    winText.text = newWin.ToString();
                }
                else if(countSlot[kvp.Key] == 5){
                    newWin = int.Parse(winText.text) + 10;

                    winText.text = newWin.ToString();
                }
            }

            index++;
        }
        
        showResults = false;
    }
}

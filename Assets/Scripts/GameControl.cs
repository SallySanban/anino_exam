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

    //game loop to check if it's time to show results
    void Update(){
        if(rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped && showResults){
            CheckResults();
        }
    }

    //spins the reels when spin button is clicked and the reels are no longer spinning
    private void OnMouseDown(){
        if(rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped){

            //checks if coins and bet is valid to spin
            if(int.Parse(coinsText.text) >= int.Parse(betText.text) && int.Parse(betText.text) != 0){
                StartCoroutine("Spin");

                //updates coins from how much was bet
                int newCoins = int.Parse(coinsText.text) - int.Parse(betText.text);

                //error checking for if coins is below 0
                if(newCoins < 0){
                    newCoins = 0;
                }
                
                coinsText.text = newCoins.ToString();
            }
        }
    }

    //calls spin pressed to alert the rows to start spinning
    private IEnumerator Spin(){
        SpinPressed();

        yield return new WaitForSeconds(0.1f);
    }

    //shows the prize results
    private void CheckResults(){
        int index = 0;

        //repeats 3 times because there are 3 rows
        while(index < 3){
            List<string> slotValues = new List<string>();

            int newWin;
            int count;

            //adds the values of the stopped slots to list
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

            //gets the distinct values from the list
            List <string> distinctSlotValues = slotValues.Distinct().ToList();

            IDictionary<string, int> countSlot = new Dictionary<string, int>();

            //counts the instances of each distinct value
            for(int i=0; i<distinctSlotValues.Count; i++){
                count = slotValues.Where(x => x != null && x.Equals(distinctSlotValues[i])).Count();
                countSlot.Add(distinctSlotValues[i], count);
            }

            foreach(KeyValuePair<string, int> kvp in countSlot){
                //adds 1 point for each row with 3 matches
                if(countSlot[kvp.Key] == 3){
                    newWin = int.Parse(winText.text) + 1;

                    winText.text = newWin.ToString();
                } //adds 5 points for each row with 4 matches
                else if(countSlot[kvp.Key] == 4){
                    newWin = int.Parse(winText.text) + 5;

                    winText.text = newWin.ToString();
                } //adds 10 points for each row with full match
                else if(countSlot[kvp.Key] == 5){
                    newWin = int.Parse(winText.text) + 10;

                    winText.text = newWin.ToString();
                }
            }

            index++;
        }

        //sets to false to make sure the addition of points only happens once
        showResults = false;
    }
}

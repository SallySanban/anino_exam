using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string firstStoppedSlot, secondStoppedSlot, thirdStoppedSlot;

    //array of y values that indicate correct position of the reels
    public float[] yValues = new float[]{-13.5742f, -11.7f, -9.82f, -7.98f, -6.04f, -4.2f, -2.32f, -0.39f, 1.45f, 3.35f, 5.23f, 7.11f, 9.01f, 10.87f, 12.78f, 14.66f, 16.54f};
    
    //starts rotating once the spin button is pressed
    void Start(){
        rowStopped = true;
        GameControl.SpinPressed += StartRotating;
    }

    //calls the rotate coroutine
    private void StartRotating(){
        firstStoppedSlot = "";
        secondStoppedSlot = "";
        thirdStoppedSlot = "";
        StartCoroutine("Rotate");
    }

    //spins the reels
    private IEnumerator Rotate(){
        rowStopped = false;
        timeInterval = 0.025f;
        int index = 0;

        //spins 30 times with a speed of timeInterval
        for(int i=0; i<30; i++){
            //if the y position is before the first correct position, change the position to the last position (which is the first position repeated)
            if(transform.position.y <= -13.5742f){
                transform.position = new Vector2(transform.position.x, 16.54f);
            }

            //changes the y value of the reels by the positions in the array
            transform.position = new Vector2(transform.position.x, yValues[index]);

            index++;

            //error checking for when index of position array is over the number of positions
            if(index > 16){
                index = 0;
            }

            yield return new WaitForSeconds(timeInterval);
        }

        index = 0;

        //random value for slowing down each reel
        randomValue = Random.Range(60,100);

        switch(randomValue % 3){
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }


        for(int i=0; i < randomValue; i++){
            //for spinning the reel (changing y)
            if(transform.position.y <= -13.5742f){
                transform.position = new Vector2(transform.position.x, 16.54f);
            }

            transform.position = new Vector2(transform.position.x, yValues[index]);

            //changes the speed
            if(i > Mathf.RoundToInt(randomValue * 0.25f)){
                timeInterval = 0.05f;
            }

            if(i > Mathf.RoundToInt(randomValue * 0.5f)){
                timeInterval = 0.1f;
            }

            if(i > Mathf.RoundToInt(randomValue * 0.75f)){
                timeInterval = 0.15f;
            }

            if(i > Mathf.RoundToInt(randomValue * 0.95f)){
                timeInterval = 0.2f;
            }

            index++;
            
            //error checking for when index of position array is over the number of positions
            if(index > 16){
                index = 0;
            }

            yield return new WaitForSeconds(timeInterval);
        }

        //assigns the firstStoppedSlot (1st row), secondStoppedSlot (2nd row), thirdStoppedSlot (3rd row) with the values of the stopped slots
        if(transform.position.y == -13.5742f){
            firstStoppedSlot = "One";
            secondStoppedSlot = "Two";
            thirdStoppedSlot = "Three";
        }
        else if(transform.position.y == -11.7f){
            firstStoppedSlot = "Two";
            secondStoppedSlot = "Three";
            thirdStoppedSlot = "Four";
        }
        else if(transform.position.y == -9.82f){
            firstStoppedSlot = "Three";
            secondStoppedSlot = "Four";
            thirdStoppedSlot = "Five";
        }
        else if(transform.position.y == -7.98f){
            firstStoppedSlot = "Four";
            secondStoppedSlot = "Five";
            thirdStoppedSlot = "Six";
        }
        else if(transform.position.y == -6.04f){
            firstStoppedSlot = "Five";
            secondStoppedSlot = "Six";
            thirdStoppedSlot = "Seven";
        }
        else if(transform.position.y == -4.2f){
            firstStoppedSlot = "Six";
            secondStoppedSlot = "Seven";
            thirdStoppedSlot = "Eight";
        }
        else if(transform.position.y == -2.32f){
            firstStoppedSlot = "Seven";
            secondStoppedSlot = "Eight";
            thirdStoppedSlot = "Nine";
        }
        else if(transform.position.y == -0.39f){
            firstStoppedSlot = "Eight";
            secondStoppedSlot = "Nine";
            thirdStoppedSlot = "Ten";
        }
        else if(transform.position.y == 1.45f){
            firstStoppedSlot = "Nine";
            secondStoppedSlot = "Ten";
            thirdStoppedSlot = "Eleven";
        }
        else if(transform.position.y == 3.35f){
            firstStoppedSlot = "Ten";
            secondStoppedSlot = "Eleven";
            thirdStoppedSlot = "Twelve";
        }
        else if(transform.position.y == 5.23f){
            firstStoppedSlot = "Eleven";
            secondStoppedSlot = "Twelve";
            thirdStoppedSlot = "Thirteen";
        }
        else if(transform.position.y == 7.11f){
            firstStoppedSlot = "Twelve";
            secondStoppedSlot = "Thirteen";
            thirdStoppedSlot = "Fourteen";
        }
        else if(transform.position.y == 9.01f){
            firstStoppedSlot = "Thirteen";
            secondStoppedSlot = "Fourteen";
            thirdStoppedSlot = "Fifteen";
        }
        else if(transform.position.y == 10.87f){
            firstStoppedSlot = "Fourteen";
            secondStoppedSlot = "Fifteen";
            thirdStoppedSlot = "Sixteen";
        }
        else if(transform.position.y == 12.78f){
            firstStoppedSlot = "Fifteen";
            secondStoppedSlot = "Sixteen";
            thirdStoppedSlot = "One";
        }
        else if(transform.position.y == 14.66f){
            firstStoppedSlot = "Sixteen";
            secondStoppedSlot = "One";
            thirdStoppedSlot = "Two";
        }
        else if(transform.position.y == 16.54f){
            firstStoppedSlot = "One";
            secondStoppedSlot = "Two";
            thirdStoppedSlot = "Three";
        }

        //triggers showing of prize results
        GameControl.showResults = true;
        rowStopped = true;
    }

    //destroys game object
    private void OnDestroy(){
        GameControl.SpinPressed -= StartRotating;
    }
}

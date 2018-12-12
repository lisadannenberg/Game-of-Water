using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option1Manager : MonoBehaviour
{

    // initialisation
    public Text scoreText;
    public Text discText;
    private int point = 0;
    public Text[] optionList;
    string current_quetion = "first";
   
    // Dataset as dictionary
    private Dictionary<string, Dictionary<string, bool>> myTable = new Dictionary<string, Dictionary<string, bool>>()
    {

        {
            "1.What is the main water source in Tallinn?", new Dictionary<string, bool>()
            {
                { "A. Baltic sea", false},
                { "B. Lake Ülemiste",true},
                { "C. Lake Peipus", false},
                { "D. Võhandu River", false},
            }


        },
        {
            "2. How many natural lakes are in Estonia?", new Dictionary<string, bool>()
            {
                { "A. ~1100", true},
                { "B. ~1500", false},
                { "C. ~200", false},
                { "D. ~500", false},
            }
        },
        {
            "3.What lake is the 5th largest lake in Europe", new Dictionary<string, bool>()
            {
                { "A. Ladoga", false},
                { "B. Peipus", true},
                { "C. Saimaa", false},
                { "D. Engure", false},
            }


        },
        {
            "4.What is the largest water flow river in Estonia?", new Dictionary<string, bool>()
            {
                { "A. Oder", false},
                { "B. Narva", true},
                { "C. Elbe", false},
                { "D. Pirita", false},
            }


        },
        // avoid No Key error by ""
         {
            "", new Dictionary<string, bool>()
            {
                { "A. Game Over", false},
                { "B. Game Over", false},
                { "C. Game Over", false},
                { "D. Game Over", false},
            }
      

        }
     
    };


// Use this for initialization
    void Start()
    {
        // score text
        scoreText = GameObject.FindGameObjectWithTag("Point").GetComponent<Text>();
        scoreText.text = "Point : " + point.ToString();

        // Expanation text
        discText = GameObject.FindGameObjectWithTag("Disc").GetComponent<Text>();

        // set first question
        stateChange(current_quetion);
        
        // Debug.Log(point); // 0

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void myClick(string button)
    {

        GameObject text = GameObject.FindGameObjectWithTag(button);

        if (current_quetion != "" && point < 3) {
            Dictionary<string, bool> temp = myTable[current_quetion];
            //foreach(KeyValuePair<string, bool> fs in temp)
            //Debug.Log(fs); // string, bool

            bool isCorrect = temp[text.GetComponentInChildren<Text>().text];
            // Debug.Log(temp[text.GetComponentInChildren<Text>().text]); // True or False
            // Debug.Log(temp[text.GetComponent<Text>().text]); // NullReferenceException: Object reference not set to an instance of an object


            if (isCorrect)
            {
                point++;
                scoreText.text = "Point : " + point.ToString();

                // Debug.Log(point); // 1 2 3 4


            }

            stateChange(current_quetion);

        } else
        {
            discText.text = "Nice! You can play again!";
        }
    }
    // change the current_question
    // arg is current_question
    private void stateChange(string name)
    {
        

        switch (name)
        {
            case "first":
                current_quetion = "1.What is the main water source in Tallinn?";
                break;
            case "1.What is the main water source in Tallinn?":
                current_quetion = "2. How many natural lakes are in Estonia?";
                break;

            case "2. How many natural lakes are in Estonia?":
                current_quetion = "3.What lake is the 5th largest lake in Europe";
                break;

            case "3.What lake is the 5th largest lake in Europe":
                current_quetion = "4.What is the largest water flow river in Estonia?";
                break;

            case "4.What is the largest water flow river in Estonia?":
                current_quetion = "";
                break;

        }


        optionList[0].text = current_quetion;

        int i = 1;
        //Debug.Log(i); // 1


        foreach (KeyValuePair<string, bool> hash in myTable[current_quetion])
        {
            // Debug.Log(hash); // [Baltic sea, False]
            optionList[i].text = hash.Key; 
            // Debug.Log(hash.Key); // Baltic sea
            // Debug.Log(hash.Value); // False
            i++;
            // Debug.Log(i); // 2 3 4 5 // 2 3 4 5

            // if(i = )

        }

    }
   


}




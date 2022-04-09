using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickerIdleFormatVolues : MonoBehaviour
{
    //list for linits format 
    private List<float> limitEnter;
    //list name for limits 
    private List<string> limitEnterNames;

    //this basic fild for see resualt set on inspector
    [SerializeField]
    private Text testText;

    //this test value can set on inspector
    [SerializeField]
    private float testValue = 10000.0f;
    //set lists
    private void Start()
    {
        //numbers 
        limitEnter = new List<float>();
        //recomed limit 10^33 = > 12 becose step 10^3
        for (int i = 0; i < 12; i++)
        {
            limitEnter.Add(Mathf.Pow(Mathf.Pow(10, 3), i));
        }
        //names
        limitEnterNames = new List<string>();
        // [0] <1000 not have name
        limitEnterNames.Add(" ");

        //K Thousand        10^3
        limitEnterNames.Add("K");

        //M Million     10^6
        limitEnterNames.Add("M");
        
        //B Billion     10^9
        limitEnterNames.Add("B");
        
        //T Trillion        10^12
        limitEnterNames.Add("T");
        
        //q Quadrillion     10^15
        limitEnterNames.Add("q");
        
        //Q Quintillion     10^18
        limitEnterNames.Add("Q");
        
        //s Sextillion      10^21
        limitEnterNames.Add("s");
        
        //S Septillion      10^24
        limitEnterNames.Add("S");
        
        //O Octillion       10^27
        limitEnterNames.Add("O");
        
        //N Nonillion       10^30
        limitEnterNames.Add("N");

        //d Decillion       10^33
        limitEnterNames.Add("d");

        //set value in text
        testText.text = FormatVolue(testValue);
    }

    //format resorse
    string FormatVolue(float volueResurs)
    {
        // construct
        string sorseName = "0";
        // check size
        int indexSize = 0;
        for (int i = 1; i < limitEnter.Count; i++)
        {

            if (volueResurs < limitEnter[i])
            {
                indexSize = i - 1;
                break;
            }

        }
        //buld volue
        sorseName = (volueResurs / limitEnter[indexSize]).ToString("F2") + " " + limitEnterNames[indexSize];
        return sorseName;
    }
}

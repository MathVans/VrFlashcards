using Assets.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;

public class SrsCalculo : MonoBehaviour
{

    //NOTES
    //The algorithm SM-2 doesn't equal to the computer implementation SuperMemo2. In fact, the 3 earliest implementations 
    //(SuperMemo1, SuperMemo2 and SuperMemo3) all used algorithm SM-2. 

    //Motivation
    //The goal was to have an efficient way to calculate the next review date for studying/learning.Removes the burden of remembering the algorithm, equations, and math from the users.

    List<GameObject> Baralho;
    public SrsCalculo(int quality, int repetitions, int previousInterval, int previousEaseFactor)
    {
        this.repetitions = repetitions;
        this.previousInterval = previousInterval;
        this.previousEaseFactor = previousEaseFactor;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

//    



        [SerializeField] public GameObject quality;

        private int interval = 0;
        private double easeFactor = 0;
        //private int quality { get; set; }
        private int repetitions { get; set; }
        private int previousInterval { get; set; }
        private double previousEaseFactor { get; set; }

        DateTime dateReview = DateTime.Now;

    //    ## Code Reference
    //### *class* supermemo2.SMTwo(easiness, interval, repetitions)

    //**Parameters:**
    //- easiness(double) - the easiness determines the interval.
    //- interval(int) - The gap/space between your next review..
    //- repetitions (int) - The count of correct response (quality >= 3) you have in a row.

    public void Calcular(string quality)
        {
        //// MessageBox.Show();
        //Console.WriteLine("ENTROU func");
        //int Quality = Int32.Parse(quality.ToString());

        //    if (Quality >= 3)
        //    {
        //    switch (repetitions)
        //        {
        //            case 0:
        //                interval = 1;
        //                break;
        //            case 1:
        //                interval = 6;
        //                break;

        //            default:
        //                double a = Math.Round(previousInterval * previousEaseFactor);
        //                interval = (int)a;

        //                break;
        //        }
        //        repetitions++;
        //        easeFactor = previousEaseFactor + (0.1 - (5 - Quality) * (0.08 + (5 - Quality) * 0.02));
        //        double teste = 0.1 - (5 - 4) * (0.08 + (5 - 4) * 0.02);
        //    Console.WriteLine(teste.ToString());
        //    }
        //    else
        //    {
        //        repetitions = 0;
        //        interval = 1;
        //        easeFactor = previousEaseFactor;
        //    }

        //    if (easeFactor < 1.3)
        //    {
        //        easeFactor = 1.3;
        //    }        //// MessageBox.Show();
        //Console.WriteLine("ENTROU func");
        //int Quality = Int32.Parse(quality.ToString());

        //    if (Quality >= 3)
        //    {
        //    switch (repetitions)
        //        {
        //            case 0:
        //                interval = 1;
        //                break;
        //            case 1:
        //                interval = 6;
        //                break;

        //            default:
        //                double a = Math.Round(previousInterval * previousEaseFactor);
        //                interval = (int)a;

        //                break;
        //        }
        //        repetitions++;
        //        easeFactor = previousEaseFactor + (0.1 - (5 - Quality) * (0.08 + (5 - Quality) * 0.02));
        //        double teste = 0.1 - (5 - 4) * (0.08 + (5 - 4) * 0.02);
        //    Console.WriteLine(teste.ToString());
        //    }
        //    else
        //    {
        //        repetitions = 0;
        //        interval = 1;
        //        easeFactor = previousEaseFactor;
        //    }

        //    if (easeFactor < 1.3)
        //    {
        //        easeFactor = 1.3;
        //    }        //// MessageBox.Show();
        //Console.WriteLine("ENTROU func");
        //int Quality = Int32.Parse(quality.ToString());

        //    if (Quality >= 3)
        //    {
        //    switch (repetitions)
        //        {
        //            case 0:
        //                interval = 1;
        //                break;
        //            case 1:
        //                interval = 6;
        //                break;

        //            default:
        //                double a = Math.Round(previousInterval * previousEaseFactor);
        //                interval = (int)a;

        //                break;
        //        }
        //        repetitions++;
        //        easeFactor = previousEaseFactor + (0.1 - (5 - Quality) * (0.08 + (5 - Quality) * 0.02));
        //        double teste = 0.1 - (5 - 4) * (0.08 + (5 - 4) * 0.02);
        //    Console.WriteLine(teste.ToString());
        //    }
        //    else
        //    {
        //        repetitions = 0;
        //        interval = 1;
        //        easeFactor = previousEaseFactor;
        //    }

        //    if (easeFactor < 1.3)
        //    {
        //        easeFactor = 1.3;
        //    }

        }


    


    // Update is called once per frame
    void Update()
    {
        // Calcular(quality.ToString());
    }
}



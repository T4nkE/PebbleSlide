using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_AI : MonoBehaviour
{
    public int Difficulty = 0; //Game Diffiulty as a whole, selected in menu
    private float PointScaling; //Factor by which points are multiplied by
    
    public float GMPointTimer = 2f;     //TIMER when the GameMasterAI(GMAI) gets points
    public float GMSpendingTimer = 5f;  //TIMER when the GMAI starts spending points
    public float DifficultyScaling;     //TIMER "more time = more difficulty" time frame
    
    public float DifficultyLevel; //what ups the difficulty after the timeframe

    private int[] PointSelection = {10,12,13,14,15}; //raw point score amount that can be given, array for variation
    private int selectedPointAmount; //raw amount of points selected for the GMAI

    private float CurrentPoints; //the current amount of points that the GMAI has

    private void Start()
    {
        // Start the coroutines to run the timers independently
        StartCoroutine(RunTimer1());  //Timer for when GameMasterAI gets points
        StartCoroutine(RunTimer2());  //Timer for when GameMasterAI gets points
        StartCoroutine(RunTimer3());  //Timer for when Difficulty scales

        if(Difficulty == -1)        //Difficulty Level 1
        {
            PointScaling = .8;         //Factor by which points are multiplied by
            DifficultyScaling = 150;    //"more time = more difficulty" time frame
        }

        if(Difficulty == 0)         //Difficulty Level 2
        {
            PointScaling = 1;          //Factor by which points are multiplied by
            DifficultyScaling = 120;    //"more time = more difficulty" time frame
        }

        if(Difficulty == 1)         //Difficulty Level 3
        {
            PointScaling = 1.2;        //Factor by which points are multiplied by
            DifficultyScaling = 90;    //"more time = more difficulty" time frame
        }

    }

    IEnumerator RunTimer1()
    {
        while (true)
        {
            yield return new WaitForSeconds(GMPointTimer);
            GivePoints();
        }
    }

    IEnumerator RunTimer2()
    {
        while (true)
        {
            yield return new WaitForSeconds(GMSpendingTimer);
            SpendPoints();
        }
    }

    IEnumerator RunTimer3()
    {
        while (true)
        {
            yield return new WaitForSeconds(DifficultyScaling);
            Function3();
        }
    }

    void GivePoints()
    {
        // Retrieve the object at a fixed index (0 to 4)
        int randomIndex = Random.Range(0, 5);

        // Retrieve the object at the random index
        GameObject selectedPointAmount = PointSelection[randomIndex];

        CurrentPoints += selectedPointAmount * 1.2
    }

    void SpendPoints()
    {
        // Your code for function2
        Debug.Log("Function2 called.");
    }

    void Function3()
    {
        // Your code for function3
        Debug.Log("Function3 called.");
    }
}

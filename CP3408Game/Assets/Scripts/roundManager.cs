using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundManager : MonoBehaviour {

    public static int round;
    public static int roundValue = 1;       

    Text text;           


    void Awake()
    {
        text = GetComponent<Text>();

        round = 1;
    }

    void Update()
    {
        setText();
    }

    void setText()
    {
        text.text = "Round: " + round;
    }
}

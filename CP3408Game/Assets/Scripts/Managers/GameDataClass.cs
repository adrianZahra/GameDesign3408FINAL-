using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataClass : MonoBehaviour {

    public static int roundNumber = 1;

    public static bool dockGate = false;
    public static bool bunkerGate = true;
    public static int round;
    public static int roundValue = 1;

    Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

        round = 1;
    }

    public void setText()
    {
        text.text = "Round: " + round;
    }
}

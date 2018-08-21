using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W1_Ehh : MonoBehaviour {
    public int add;
    public int score;
	// Use this for initialization
	void Start () {
        W1_Intro.score += add;
        score += add;
        Debug.Log(score);
        // += equates to [ Intro.score = Intro.score + add; ]
    }

}

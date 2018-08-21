using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ehh : MonoBehaviour {
    public int add;
    public int score;
	// Use this for initialization
	void Start () {
        Intro.score += add;
        score += add;
        Debug.Log(score);
        // += equates to [ Intro.score = Intro.score + add; ]
    }

}

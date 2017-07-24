using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour {

    public Text txtScore;

    public int totScore = 0;
	// Use this for initialization
	void Start () {
        DipScore(0);
	}
    public void DipScore(int score)
    {
        totScore += score;
        txtScore.text = "score<color=#ff0000>" + totScore.ToString() + "</color>";
    }
}

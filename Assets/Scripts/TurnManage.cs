using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManage : MonoBehaviour{
    public bool turn;
    public bool slcflag = true;
    public Text turnText;
    public Text endText;
    // Start is called before the first frame update
    void Start(){
        int number = Random.Range(0, 2);
        if (number == 0) {
            turn = false;
        } else {
            turn = true;
        }
    }

    // Update is called once per frame
    void Update(){
        if (turn == false) {
            turnText.text = "Player2の番です";
        } else {
            turnText.text = "Player1の番です";
        }
    }
    public void End(string a) {
        endText.text = a;

    }
}

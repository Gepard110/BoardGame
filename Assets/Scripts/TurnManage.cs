using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManage : MonoBehaviour{
    public bool flag;
    public Text turnText;
    // Start is called before the first frame update
    void Start(){
        int number = Random.Range(0, 2);
        if (number == 0) {
            flag = false;
        } else {
            flag = true;
        }
    }

    // Update is called once per frame
    void Update(){
        if (flag == false) {
            turnText.text = "Player2の番です";
        } else {
            turnText.text = "Player1の番です";
        }
    }
}

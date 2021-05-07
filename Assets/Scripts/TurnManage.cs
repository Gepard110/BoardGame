using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManage : MonoBehaviour{
    public int flag;
    public Text turnText;
    // Start is called before the first frame update
    void Start(){
        flag = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update(){
        if (flag == 0) {
            turnText.text = "相手の番です";
        } else {
            turnText.text = "あなたの番です";
        }
    }
}

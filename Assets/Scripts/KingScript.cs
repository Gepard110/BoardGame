using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingScript : MonoBehaviour
{
    GameObject ClickedObject;
    GameObject TurnManager;
    TurnManage script;
    bool select = false;
    // Start is called before the first frame update
    void Start(){
        TurnManager = GameObject.Find("Board");
        script = TurnManager.GetComponent<TurnManage>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ClickedObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit)) {
                ClickedObject = hit.collider.gameObject;
            }
            Vector3 pos = this.transform.position;
            if (Vector2.Distance(pos, ClickedObject.transform.position) == 0) {
                select = true;
            }
        }
        if (select == true) {
            if (this.gameObject.CompareTag("Player1")) {
                if (script.flag == true) {
                    move();
                }
            } else if (this.gameObject.CompareTag("Player2")) {
                if (script.flag == false) {
                    move();
                }
            }
        }
    }
    void move() {
        if (Input.GetMouseButtonDown(0)) {
            ClickedObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit)) {
                ClickedObject = hit.collider.gameObject;
            }
            Vector3 pos = this.transform.position;
            if (Vector2.Distance(pos, ClickedObject.transform.position) <= Mathf.Sqrt(2)&& Vector2.Distance(pos, ClickedObject.transform.position)!=0) {
                pos.x = ClickedObject.transform.position.x;
                pos.y = ClickedObject.transform.position.y;
                this.transform.position = pos;
                script.flag = !script.flag;
                select = false;
            }
        }
    }
}

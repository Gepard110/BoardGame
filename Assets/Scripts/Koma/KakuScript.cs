using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakuScript : MonoBehaviour {
    GameObject ClickedObject;
    GameObject TurnManager;
    public GameObject Hit;
    TurnManage script;
    bool select = false;
    int HP = 5;
    // Start is called before the first frame update
    void Start() {
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
            //セレクト
            if (Vector2.Distance(pos, ClickedObject.transform.position) == 0) {
                if (script.slcflag == true) {
                    if (this.gameObject.CompareTag("Player1")) {
                        if (script.turn == true) {
                            select = true;
                            script.slcflag = false;
                        }
                    } else if (this.gameObject.CompareTag("Player2")) {
                        if (script.turn == false) {
                            select = true;
                            script.slcflag = false;
                        }
                    }
                }
            }
        }
        //移動、攻撃
        if (select == true && ClickedObject != null) {
            if (ClickedObject.gameObject.CompareTag("Board")) {
                if (this.gameObject.CompareTag("Player1")) {
                    if (script.turn == true) {
                        Move();
                    }
                } else if (this.gameObject.CompareTag("Player2")) {
                    if (script.turn == false) {
                        Move();
                    }
                }
            } else if (ClickedObject.gameObject.CompareTag("Player2") && this.gameObject.CompareTag("Player1")) {
                if (script.turn == true) {
                    Create();
                }
            } else if (ClickedObject.gameObject.CompareTag("Player1") && this.gameObject.CompareTag("Player2")) {
                if (script.turn == false) {
                    Create();
                }
            }
        }
        if (HP == 0) {
            script.turn = !script.turn;
            select = false;
            script.slcflag = true;
            Destroy(this.gameObject);
        }
    }
    void Move() {
        if (Input.GetMouseButtonDown(0)) {
            ClickedObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit)) {
                ClickedObject = hit.collider.gameObject;
            }
            Vector3 pos = this.transform.position;
            if (Mathf.Abs(pos.x - ClickedObject.transform.position.x) == Mathf.Abs(pos.y - ClickedObject.transform.position.y) && Vector2.Distance(pos, ClickedObject.transform.position) != 0) {
                pos.x = ClickedObject.transform.position.x;
                pos.y = ClickedObject.transform.position.y;
                this.transform.position = pos;
                script.turn = !script.turn;
                select = false;
                script.slcflag = true;
            }
        }
    }
    void Create() {
        Vector3 pos = this.transform.position;
        if (Vector2.Distance(pos, ClickedObject.transform.position) <= Mathf.Sqrt(2) && Vector2.Distance(pos, ClickedObject.transform.position) != 0) {
            Instantiate(Hit, ClickedObject.transform.position, Quaternion.identity);
            ClickedObject = null;
            script.turn = !script.turn;
            select = false;
            script.slcflag = true;
        }
    }
    void Damage(int damage) {
        HP -= damage;
    }
    void OnTriggerEnter(Collider other) {
        Vector3 pos = this.transform.position;
        if (other.gameObject.CompareTag("Enemy")) {
            Damage(1);
            Destroy(other.gameObject);
            Debug.Log(HP);
        }
    }
}

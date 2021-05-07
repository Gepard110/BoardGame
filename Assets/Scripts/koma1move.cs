using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koma1move : MonoBehaviour
{
    GameObject ClickedObject;
    GameObject TurnManager;
    TurnManage script;
    // Start is called before the first frame update
    void Start(){
        TurnManager = GameObject.Find("Board");
        script = TurnManager.GetComponent<TurnManage>();
    }

    // Update is called once per frame
    void Update() {
        if (script.flag == 1) {
            if (Input.GetMouseButtonDown(0)) {
                ClickedObject = null;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit)) {
                    ClickedObject = hit.collider.gameObject;
                }
                Vector3 pos = this.transform.position;
                if (Vector3.Distance(pos,ClickedObject.transform.position) <= Mathf.Sqrt(2)) {
                    pos.x = ClickedObject.transform.position.x;
                    pos.y = ClickedObject.transform.position.y;
                    this.transform.position = pos;
                    script.flag = 0;
                }
            }
        }
    }
}

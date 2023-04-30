using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class island : MonoBehaviour
{
    public List<GameObject> fields = new List<GameObject>();
    public List<GameObject> cats = new List<GameObject>();
    public GameObject boat;

    public int weath = 0;
    public int milk = 0;

    void Start() {
        foreach (Transform child in transform) {
            if (child.name == "field") {
                fields.Add(child.gameObject);
            } else if (child.name == "cat") {
                cats.Add(child.gameObject);
            } else if (child.name == "boat") {
                boat = child.gameObject;
            }
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            harvest();
        }
    }

    void harvest () {
        foreach (GameObject field in fields) {
            foreach (Transform child in field.transform) {
                Debug.Log(child.name);
                if (child.GetComponent<field_tile>().harvestable) {
                    if (child.name == "wheat") {
                        weath += 1;
                    } else if (child.name == "milk") {
                        milk += 1;
                    }
                    child.GetComponent<field_tile>().harvest();
                }
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoHandler : MonoBehaviour {

    float fall = 0;
    public float fallSpeed = 1;
    private GameMapHandler gameGrid;
    public bool allowRotation = true;
    bool limitRotation = false;
    private Vector2[] blockPositions;

    // Use this for initialization
    void Start () {
        gameGrid = GameObject.Find("Grid").GetComponent<GameMapHandler>();
        BlockPositions();
    }
	
	// Update is called once per frame
	void Update () {
        CheckUserInput();
    }

    // Checks for typical input
    void CheckUserInput() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(1, 0, 0);
            //if (!CheckIsValidPosition())
            //    transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-1, 0, 0);
            //if (!CheckIsValidPosition())
            //    transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (allowRotation) { //look this over for improvement
                if (limitRotation) {
                    if (transform.rotation.z == 0) {
                        transform.Rotate(0, 0, 90);
                        //if (!CheckIsValidPosition())
                        //    transform.Rotate(0, 0, -90);
                    }
                    else
                        transform.Rotate(0, 0, -90);
                    //if (!CheckIsValidPosition())
                    //    transform.Rotate(0, 0, 90);
                }
                else {
                    transform.Rotate(0, 0, 90);
                    //if (!CheckIsValidPosition())
                    //    transform.Rotate(0, 0, -90);
                }
            }
        }

        // Fall speed determined by fallSpeed from 1 block/s to 1 block/0.05s
        // Fall by 1 per DownArrow key press
        // Fall disabled if fallSpeed = 0
        else if (fallSpeed != 0 && (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= (21 - fallSpeed * 2) / 20)) {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
            //if (!CheckIsValidPosition()) {
            //    transform.position += new Vector3(0, 1, 0);
            //}    
        }
    }
    private bool CheckIsValidPosition() { 
        // take tetromino position and add mino position an convert that into index to check validity

        if (true) {
            return false;
        }
        else
            return true;
    }

    // Store vector information for block positions in blockPositions array
    private void BlockPositions() {
        blockPositions = new Vector2[4];
        for (int i = 0; i < transform.childCount; i++) {
            Transform t = transform.GetChild(i);
            if (t.gameObject.tag == "Mino") {
                Vector2 v = new Vector2(t.localPosition.x, t.localPosition.y);
                blockPositions[i] = v;
            }
        }
    }
}

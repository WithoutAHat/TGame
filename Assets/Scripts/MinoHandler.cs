using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called whenever there is a collision with the attached collider
    void OnCollisionEnter2D(Collision2D col) {
        //if (col.gameObject.tag == "Mino") {
        //    GameHandler game = transform.parent.parent.parent.GetComponent<GameHandler>();
        //    GameObject tetromino = (GameObject)Instantiate(Resources.Load("Tetromino_L"));
        //    tetromino.transform.position.Set(0, 0, 0);
        //    game.CurrentTetromino = tetromino;

        //    Debug.Log("end");
        //}
        //Debug.Log("skipped");
    }
}

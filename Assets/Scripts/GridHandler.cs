using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour {

    public static int // Defining grid boundaries
        gridHorizontalMaxX = 18, gridHorizontalMinX = -18,
        gridHorizontalMaxY = 5, gridHorizontalMinY = -5,
        gridVerticalMaxX = 5, gridVerticalMinX = -5,
        gridVerticalMaxY = 18, gridVerticalMinY = -18;
    private int[] Occupied;

    // Use this for initialization
    void Start () {
        Occupied = new int[36 * 36];
        MakeOccupiedIntoPlusStyleBoundaries();
        DebugLogOccupied();
    }
	
	// Update is called once per frame
	void Update () {
	}

    // Use to check if Tetromino is in the grid
    public bool CheckIsInsideGrid (Vector2 position) {
        //Debug.Log(gridHorizontalMinX + " < " + position.x + " < " + gridHorizontalMaxX);
        if ((position.x > gridHorizontalMinX && position.x < gridHorizontalMaxX &&
            position.y > gridHorizontalMinY && position.y < gridHorizontalMaxY) ||
           (position.x > gridVerticalMinX && position.x < gridVerticalMaxX &&
            position.y > gridVerticalMinY && position.y < gridVerticalMaxY)) {
            //Debug.Log("Inside");
            return true;
        }
        else {
            //Debug.Log("!Inside");
            return false;
        }
    }

    // Use to initialize isOccupied
    private void MakeOccupiedIntoPlusStyleBoundaries() {
        // Eventually add some code to reset the map and boundaries

        // Remove all blocks from Occupied
        foreach (int i in Occupied)
            Occupied[i] = 0;

        // Set non-removable blocks in Occupied
        for (int i = 0; i < 13; i++) {
            // Top 2 lines
            Occupied[i * 36 + 12] = 2;
            Occupied[i * 36 + 23] = 2;
            // Bottom 2 lines
            Occupied[(i + 23) * 36 + 12] = 2;
            Occupied[(i + 23) * 36 + 23] = 2;

            // Left 2 Lines
            Occupied[12 * 36 + i] = 2;
            Occupied[12 * 36 + i + 23] = 2;
            // Right 2 Lines
            Occupied[23 * 36 + i] = 2;
            Occupied[23 * 36 + i + 23] = 2;
        }
    }

    // Use to set a single block as a boundary
    public void SetBoundary (Vector2 v) {
        // remove the vector coords decimals or make them into 0.5s as necessary 
    }

    // Use to print a debug of isOccupied
    public void DebugLogOccupied () {
        string line = "";
        for (int i = 0; i < 36; i++) {
            for (int j = 0; j < 36; j++) {
                line += Occupied[i * 36 + j].ToString();
            }
            line += "\n";
        }
        Debug.Log(line);
    }

    // Use to add to the Occupied Array blocks that can be removed
    public void AddToOccupied (Vector2[] toMakeOccupied) {
        

    }
}
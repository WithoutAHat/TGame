using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq;

public class GameMapHandler : MonoBehaviour {

    private int[] newOccupied, oldOccupied;

    // Use this for initialization
    void Start () {
        MakeIntoPlusStyleBoundaries();
        CheckForClear();


        DebugLogNewOccupied();
        DebugLogOldOccupied();
    }
	
	// Update is called once per frame
	void Update () {
	}

    // Initializes Occupied arrays with + style boundaries
    private void MakeIntoPlusStyleBoundaries() {
        // Eventually add some code to reset the map and boundaries
        // Destroying all blocks

        newOccupied = new int[36 * 36];
        oldOccupied = new int[36 * 36];

        // Remove all blocks from Occupied
        for (int i = 0; i < 36 * 36; i++) 
            newOccupied[i] = 0;

        // Set non-removable blocks in Occupied
        for (int i = 0; i < 13; i++) {
            // Top 2 lines
            newOccupied[i * 36 + 12] = 2;
            newOccupied[i * 36 + 23] = 2;
            // Bottom 2 lines
            newOccupied[(i + 23) * 36 + 12] = 2;
            newOccupied[(i + 23) * 36 + 23] = 2;

            // Left 2 Lines
            newOccupied[12 * 36 + i] = 2;
            newOccupied[12 * 36 + i + 23] = 2;
            // Right 2 Lines
            newOccupied[23 * 36 + i] = 2;
            newOccupied[23 * 36 + i + 23] = 2;
        }
        // Middle 2x2 square
        newOccupied[18 * 36 + 18] = 2;
        newOccupied[18 * 36 + 19] = 2;
        newOccupied[19 * 36 + 18] = 2;
        newOccupied[19 * 36 + 19] = 2;

        // Make oldOccupied the same as newOccupied
        for (int i = 0; i < 36 * 36; i++) 
            oldOccupied[i] = newOccupied[i];
        
    }

    // Checks for a clearing area
    private void CheckForClear() {
        for (int i = 0; i < 36 * 36; i++) {
            // Check for filled 4*4 areas
            // Then clear them
        }
    }

    // Use to create a block at Vector2 coordinate
    private void CreateBlockAtBoundary(Vector2 coordinate) {

    }

    // Use to create a block at int coordinate
    private void CreateBlockAtBoundary(int coordinate) {

    }
    
    // Use to set a single block as a boundary
    public void SetBoundary (Vector2 v) {
        // remove the vector coords decimals or make them into 0.5s as necessary 
    }

    // Use to add to the Occupied Array blocks that can be removed
    public void AddToOccupied(Vector2[] toMakeOccupied) {


    }

    // Use to print a debug of newOccupied
    public void DebugLogNewOccupied () {
        string line = "";
        for (int i = 0; i < 36; i++) {
            for (int j = 0; j < 36; j++) {
                line += newOccupied[i * 36 + j].ToString();
            }
            line += "\n";
        }
        Debug.Log(line);
    }

    // Use to print a debug of oldOccupied
    public void DebugLogOldOccupied() {
        string line = "";
        for (int i = 0; i < 36; i++) {
            for (int j = 0; j < 36; j++) {
                line += oldOccupied[i * 36 + j].ToString();
            }
            line += "\n";
        }
        Debug.Log(line);
    }
}
using UnityEngine;
using System.Collections;

// DrawGizmoGrid.cs
// draws a useful reference grid in the editor in Unity. 
// 09/01/15 - Hayden Scott-Baron
// twitter.com/docky 
// no attribution needed, but please tell me if you like it ^_^

public class ColoredGrid : MonoBehaviour {
    // universal grid scale
    public float gridScale = 1f;

    // extents of the grid
    private int minX = -10, minY = -10, maxX = 10, maxY = 10;

    // nudges the whole grid rel
    public Vector3 gridOffset = Vector3.zero;

    // choose a colour for the gizmos
    public int gizmoMajorLines;
    public Color gizmoLineColor;

    // rename + centre the gameobject upon first time dragging the script into the editor. 
    //void Reset() {
    //    if (name == "GameObject")
    //        name = "~~ GIZMO GRID ~~";

    //    transform.position = Vector3.zero;
    //}

    // draw the grid
    void OnDrawGizmos() {
        // orient to the gameobject, so you can rotate the grid independently if desired
        Gizmos.matrix = transform.localToWorldMatrix;

        // set colours
        //Color dimColor = new Color(gizmoLineColor.r, gizmoLineColor.g, gizmoLineColor.b, 0.25f * gizmoLineColor.a);
        //Color brightColor = Color.Lerp(Color.white, gizmoLineColor, 0.75f);

        // draw the horizontal lines
        for (int x = minX; x < maxX + 1; x++) {

            Gizmos.color = Color.red;
           
            if (x > -5 && x < 5) {   
                Vector3 pos1 = new Vector3(x, minY, 0) * gridScale;
                Vector3 pos2 = new Vector3(x, maxY, 0) * gridScale;

                Gizmos.DrawLine((gridOffset + pos1), (gridOffset + pos2));
            }
            else {
                Vector3 pos1 = new Vector3(x, -4, 0) * gridScale;
                Vector3 pos2 = new Vector3(x, 4, 0) * gridScale;

                Gizmos.DrawLine((gridOffset + pos1), (gridOffset + pos2));
            }
        }
        
        // draw the vertical lines
        for (int y = minY; y < maxY + 1; y++) {

            Gizmos.color = Color.red;

            if (y > -5 && y < 5) {
                Vector3 pos1 = new Vector3(minX, y, 0) * gridScale;
                Vector3 pos2 = new Vector3(maxX, y, 0) * gridScale;

                Gizmos.DrawLine((gridOffset + pos1), (gridOffset + pos2));
            }
            else {
                Vector3 pos1 = new Vector3(-4, y, 0) * gridScale;
                Vector3 pos2 = new Vector3(4, y, 0) * gridScale;

                Gizmos.DrawLine((gridOffset + pos1), (gridOffset + pos2));
            }
        }
    }
}
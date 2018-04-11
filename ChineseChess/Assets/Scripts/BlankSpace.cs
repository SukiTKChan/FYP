using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankSpace : PieceControl
{
    //constructor
    internal override bool IsAlive()
    {
        throw new System.NotImplementedException();
    }

    internal override List<PositionOnBoard> LegalMoves()
    {
        return null;
    }
    internal BlankSpace(PositionOnBoard positionOnBoard)
    {
        pieceID = 0;
        position = positionOnBoard;
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

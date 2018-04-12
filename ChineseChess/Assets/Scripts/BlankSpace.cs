using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankSpace : PieceControl
{
    //constructor
    internal BlankSpace(PositionOnBoard positionOnBoard)
    {
        pieceID = 0;
        position = positionOnBoard;
    }
    internal override bool IsAlive()
    {
        throw new System.NotImplementedException();
    }

    internal override List<PositionOnBoard> LegalMoves()
    {
        return null;
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

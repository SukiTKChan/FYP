using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : PieceControl
{
    internal King(Colour red, PositionOnBoard positionOnBoard)
    {
        color = red;
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

    internal override bool IsAlive()
    {
        throw new System.NotImplementedException();
    }

    internal override List<PositionOnBoard> LegalMoves()
    {
        List<PositionOnBoard> movesFound = new List<PositionOnBoard>();

        //moves one space vertically or horizontally only , cannot leave its palace
        if (position.IsInMyPalace(base.color))
        {
            movesFound.Add(new PositionOnBoard(position.Hpos + 1, position.Vpos));
            movesFound.Add(new PositionOnBoard(position.Hpos - 1, position.Vpos));
            movesFound.Add(new PositionOnBoard(position.Hpos, position.Vpos +1));
            movesFound.Add(new PositionOnBoard(position.Hpos, position.Vpos -1));
        }


        List<PositionOnBoard> legalMovesFound = new List<PositionOnBoard>();
        foreach (PositionOnBoard move in movesFound)
            if (IsLegal(move)) legalMovesFound.Add(move);

        return legalMovesFound;
    }

    private bool IsLegal(PositionOnBoard move)
    {
        return move.IsOnBoard() && !theBoard.isPositionOccupiedbyA(move, base.color) && move.IsInMyPalace(base.color);
    }
}

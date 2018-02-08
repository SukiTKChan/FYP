using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : PieceControl
{
    internal Rook(Colour red, PositionOnBoard positionOnBoard)
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
        //Moves any number of spaces vertically or horizontally until it meets another piece or the edge of the board.
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Hpos + 1 : position.Hpos - 1)));
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Hpos - 1 : position.Hpos + 1)));
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Vpos + 1 : position.Vpos - 1)));
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Vpos - 1 : position.Vpos + 1)));

        List<PositionOnBoard> legalMovesFound = new List<PositionOnBoard>();
        foreach (PositionOnBoard move in movesFound)
            if (IsLegal(move)) legalMovesFound.Add(move);

        return legalMovesFound;
    }

    private bool IsLegal(PositionOnBoard move)
    {
        return move.IsOnBoard() && !theBoard.isPositionOccupiedbyA(move, base.color);
    }
}

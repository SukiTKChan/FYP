using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : PieceControl
{
    internal Bishop(Colour red, PositionOnBoard positionOnBoard)
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

        //must be on own side of board, moves exactly two points in any diagonal direction 
        if (position.OnMySideOfRiver(base.color))

        {
            movesFound.Add(new PositionOnBoard(position.Hpos + 2, position.Vpos + 2));
            movesFound.Add(new PositionOnBoard(position.Hpos + 2, position.Vpos - 2));
            movesFound.Add(new PositionOnBoard(position.Hpos - 2, position.Vpos - 2));
            movesFound.Add(new PositionOnBoard(position.Hpos - 2, position.Vpos + 2));
        }

        //creating a list to store all legal moves,if move found and it is legal, add it to the list
        //return all the possible legal moves
        List<PositionOnBoard> legalMovesFound = new List<PositionOnBoard>();
        foreach (PositionOnBoard move in movesFound)
            if (IsLegal(move)) legalMovesFound.Add(move);

        return legalMovesFound;
    }
    private bool IsLegal(PositionOnBoard move)
    {
        return move.IsOnBoard() && !theBoard.isPositionOccupiedbyA(move, base.color) && move.NotInAnyPalace() && move.OnMySideOfRiver(base.color);
    }
}

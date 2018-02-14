using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PieceControl
{
    internal Knight(Colour red, PositionOnBoard positionOnBoard)
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
        //Knight can move one point in any direction horizontally or vertically, plus one diagonal move. 
        //If the first point of the horizontal or vertical move is blocked by a piece, 
        //then the Knight may not move in that direction
        //Knight cannot jump over occupied places

        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Hpos + 1 : position.Hpos - 1)));
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Hpos - 1 : position.Hpos + 1)));
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Vpos + 1 : position.Vpos - 1)));
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Vpos - 1 : position.Vpos + 1)));

        //creating a list to store all legal moves,if move found and it is legal, add it to the list
        //return all the possible legal moves
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : PieceControl
{
    GameObject PawnPrefab;


    internal Pawn(Colour red, PositionOnBoard positionOnBoard)
    {
        color = red;
        position = positionOnBoard;
    }

    // Use this for initialization
    void Start ()
    {
        //position
        //GameObject go = Instantiate(PawnPrefab,);
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
        //move one space forward, if on its side of river
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Vpos + 1 : position.Vpos - 1)));

        //if on other side of river, can move forward, left and right 
        if (!position.OnMySideOfRiver(base.color) )
   
        {
            movesFound.Add(new PositionOnBoard(position.Hpos+1, position.Vpos  ));
            movesFound.Add(new PositionOnBoard(position.Hpos-1, position.Vpos  ));
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
        return move.IsOnBoard() && !theBoard.isPositionOccupiedbyA(move, base.color) && move.NotInAnyPalace();
    }
}

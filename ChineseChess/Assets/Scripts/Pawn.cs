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
        //move one space forward, never go diagonally
        movesFound.Add(new PositionOnBoard(position.Hpos, (base.color == Colour.Red ? position.Vpos + 1 : position.Vpos - 1)));
        if (!position.OnMySideOfRiver(base.color) )
   
        {
            movesFound.Add(new PositionOnBoard(position.Hpos+1, position.Vpos  ));
            movesFound.Add(new PositionOnBoard(position.Hpos-1, position.Vpos  ));
        }

        List<PositionOnBoard> legalMovesFound = new List<PositionOnBoard>();
        foreach (PositionOnBoard move in movesFound)
            if (IsLegal(move)) legalMovesFound.Add(move);

        return legalMovesFound;
    }

    private bool IsLegal(PositionOnBoard move)
    {
        return move.IsOnBoard() && theBoard.isPOsitionOccupiedbyA(position, base.color);
    }
}

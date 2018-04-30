using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceControl 
{

    internal BoardAI theBoard;

    internal PositionOnBoard position;

    public enum Colour { Red, Black,Empty};

    public Colour color;

    internal int pieceID=0;

    internal abstract bool IsAlive();
    
    internal abstract List<PositionOnBoard> LegalMoves();

    internal void LinktoBoard(BoardAI boardAI)
    {
        theBoard = boardAI;
    }
}

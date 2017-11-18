using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceControl : MonoBehaviour {

    internal BoardAI theBoard;

    internal PositionOnBoard position;

    internal enum Colour { Red, Black};

    internal Colour color;

    internal abstract bool IsAlive();
    
    internal abstract List<PositionOnBoard> LegalMoves();

    internal void LinktoBoard(BoardAI boardAI)
    {
        theBoard = boardAI;
    }
}

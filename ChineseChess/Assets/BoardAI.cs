using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BoardAI
{

    internal PieceControl[,] theboard;
    public BoardAI(int NumberHorizontal, int NumberVertical)
    {
        theboard = new PieceControl[NumberHorizontal, NumberVertical];

        setupPieces();
    }

    private void setupPieces()
    {

        theboard[3, 6] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(3,6));
        theboard[3, 6].LinktoBoard(this);
    }



    internal bool isPOsitionOccupiedbyA(PositionOnBoard position, PieceControl.Colour color)
    {
        return (theboard[position.Hpos, position.Vpos]) &&  theboard[position.Hpos, position.Vpos].color == color;
    }
}
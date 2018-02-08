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

        //theboard[1, 7] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(1,7));
        //theboard[4, 1] = new King(PieceControl.Colour.Red, new PositionOnBoard(4, 1));
        //theboard[5, 2] = new Guard(PieceControl.Colour.Red, new PositionOnBoard(5, 2));
        //theboard[4, 4] = new Bishop(PieceControl.Colour.Red, new PositionOnBoard(4, 4));
        theboard[4, 5] = new Rook(PieceControl.Colour.Red, new PositionOnBoard(4, 5));
        theboard[4, 5].LinktoBoard(this);
    }



    internal bool isPositionOccupiedbyA(PositionOnBoard position, PieceControl.Colour color)
    {
        return (theboard[position.Hpos, position.Vpos]) &&  theboard[position.Hpos, position.Vpos].color == color;
    }
}
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
        //each side has 16 pieces (1 King, 2 Guards, 2 Bishop, 2 Rooks, 2 Knight,2 Cannons,5 Pawns)

        //setting up all the black pieces (top half of board)
        theboard[4, 9] = new King(PieceControl.Colour.Black, new PositionOnBoard(4,9));
        theboard[3, 9] = new Guard(PieceControl.Colour.Black, new PositionOnBoard(3, 9));
        theboard[5, 9] = new Guard(PieceControl.Colour.Black, new PositionOnBoard(5, 9));
        theboard[2, 9] = new Bishop(PieceControl.Colour.Black, new PositionOnBoard(2, 9));
        theboard[6, 9] = new Bishop(PieceControl.Colour.Black, new PositionOnBoard(6, 9));
        theboard[1, 9] = new Knight(PieceControl.Colour.Black, new PositionOnBoard(1, 9));
        theboard[7, 9] = new Knight(PieceControl.Colour.Black, new PositionOnBoard(7, 9));
        theboard[9, 9] = new Rook(PieceControl.Colour.Black, new PositionOnBoard(9, 9));
        theboard[8, 9] = new Rook(PieceControl.Colour.Black, new PositionOnBoard(8, 9));
        theboard[1, 7] = new Cannon(PieceControl.Colour.Black, new PositionOnBoard(1, 7));
        theboard[7, 7] = new Cannon(PieceControl.Colour.Black, new PositionOnBoard(7, 7));
        theboard[6, 9] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(6, 9));
        theboard[2, 6] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(2, 6));
        theboard[4, 6] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(4, 6));
        theboard[6, 6] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(6, 6));
        theboard[8, 6] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(8, 6));

        //setting up all the red pieces (button half of board)
        theboard[4, 0] = new King(PieceControl.Colour.Red, new PositionOnBoard(4, 0));
        theboard[3, 0] = new Guard(PieceControl.Colour.Red, new PositionOnBoard(3, 0));
        theboard[5, 0] = new Guard(PieceControl.Colour.Red, new PositionOnBoard(5, 0));
        theboard[2, 0] = new Bishop(PieceControl.Colour.Red, new PositionOnBoard(2, 0));
        theboard[6, 0] = new Bishop(PieceControl.Colour.Red, new PositionOnBoard(6, 0));
        theboard[1, 0] = new Knight(PieceControl.Colour.Red, new PositionOnBoard(1, 0));
        theboard[7, 0] = new Knight(PieceControl.Colour.Red, new PositionOnBoard(7, 0));
        theboard[0, 0] = new Rook(PieceControl.Colour.Red, new PositionOnBoard(0, 0));
        theboard[8, 0] = new Rook(PieceControl.Colour.Red, new PositionOnBoard(8, 0));
        theboard[1, 2] = new Cannon(PieceControl.Colour.Red, new PositionOnBoard(1, 2));
        theboard[7, 2] = new Cannon(PieceControl.Colour.Red, new PositionOnBoard(7, 2));
        theboard[0, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(0, 3));
        theboard[2, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(2, 3));
        theboard[4, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(4, 3));
        theboard[6, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(6, 3));
        theboard[8, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(8, 3));

        

        //theboard[4, 7].LinktoBoard(this);
    }


    internal bool isPositionOccupiedbyA(PositionOnBoard position, PieceControl.Colour color)
    {
        return (theboard[position.Hpos, position.Vpos]) &&  theboard[position.Hpos, position.Vpos].color == color;
    }



    internal bool isPositionOccupied(PositionOnBoard positionOnBoard)
    {
        return isPositionOccupiedbyA(positionOnBoard, PieceControl.Colour.Red) || 
            isPositionOccupiedbyA(positionOnBoard, PieceControl.Colour.Black);
    }
}
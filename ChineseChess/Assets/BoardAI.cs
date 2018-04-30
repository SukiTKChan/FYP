using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BoardAI
{
    int numberOfRows;
    int numberofColumns;

    List<PieceControl> redPieces, blackPieces; 

    internal PieceControl[,] theboard;
    internal BlankSpace blankSpace;
    TreeNode mainAITree;
    TreeNode currentNode;
    //create tree

    public BoardAI(int NumberHorizontal, int NumberVertical)
    {
        redPieces = new List<PieceControl>();
        blackPieces = new List<PieceControl>();

        theboard = new PieceControl[NumberHorizontal, NumberVertical];
        numberOfRows = NumberHorizontal;
        numberofColumns = NumberVertical;
        setupPieces();

        mainAITree = new TreeNode(CurrentBoard());
        currentNode = mainAITree;
        processBlackPiecesMove();
        processRedPiecesMove();

    }

    private void setupPieces()
    {

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberofColumns; j++)
            {
                theboard[i, j] = new BlankSpace(new PositionOnBoard(i, j));
            }
        }

        //each side has 16 pieces (1 King, 2 Guards, 2 Bishop, 2 Rooks, 2 Knight,2 Cannons,5 Pawns)
        //setting up all the black pieces (top half of board)
        //each pieces is added to the board

       
        King king = new King(PieceControl.Colour.Black, new PositionOnBoard(4, 9),this);
        theboard[4, 9] = king;
        blackPieces.Add(king);

        theboard[3, 9] = new Guard(PieceControl.Colour.Black, new PositionOnBoard(3, 9),this);
        blackPieces.Add(theboard[3, 9]);

        theboard[5, 9] = new Guard(PieceControl.Colour.Black, new PositionOnBoard(5, 9),this);
        blackPieces.Add(theboard[5, 9]);

        theboard[2, 9] = new Bishop(PieceControl.Colour.Black, new PositionOnBoard(2, 9),this);
        blackPieces.Add(theboard[2, 9]);

        theboard[6, 9] = new Bishop(PieceControl.Colour.Black, new PositionOnBoard(6, 9), this);
        blackPieces.Add(theboard[6, 9]);

        theboard[1, 9] = new Knight(PieceControl.Colour.Black, new PositionOnBoard(1, 9), this);
        blackPieces.Add(theboard[1, 9]);

        theboard[7, 9] = new Knight(PieceControl.Colour.Black, new PositionOnBoard(7, 9), this);
        blackPieces.Add(theboard[7, 9]);

        theboard[0, 9] = new Rook(PieceControl.Colour.Black, new PositionOnBoard(0, 9), this);
        blackPieces.Add(theboard[0, 9]);

        theboard[8, 9] = new Rook(PieceControl.Colour.Black, new PositionOnBoard(8, 9), this);
        blackPieces.Add(theboard[8, 9]);

        theboard[1, 7] = new Cannon(PieceControl.Colour.Black, new PositionOnBoard(1, 7), this);
        blackPieces.Add(theboard[1, 7]);

        theboard[7, 7] = new Cannon(PieceControl.Colour.Black, new PositionOnBoard(7, 7), this);
        blackPieces.Add(theboard[7, 7]);

        theboard[6, 9] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(6, 9), this);
        blackPieces.Add(theboard[6, 9]);

        theboard[2, 6] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(2, 6), this);
        blackPieces.Add(theboard[2, 6]);

        theboard[4, 6] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(4, 6), this);
        blackPieces.Add(theboard[4, 6]);

        theboard[6, 6] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(6, 6), this);
        blackPieces.Add(theboard[6, 6]);

        theboard[8, 6] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(8, 6), this);
        blackPieces.Add(theboard[8, 6]);

        //setting up all the red pieces (button half of board)
        //add each piece to the board
        theboard[4, 0] = new King(PieceControl.Colour.Red, new PositionOnBoard(4, 0),this);
        redPieces.Add(theboard[4, 0]);

        theboard[3, 0] = new Guard(PieceControl.Colour.Red, new PositionOnBoard(3, 0),this);
        redPieces.Add(theboard[3, 0]);

        theboard[5, 0] = new Guard(PieceControl.Colour.Red, new PositionOnBoard(5, 0),this);
        redPieces.Add(theboard[5, 0]);

        theboard[2, 0] = new Bishop(PieceControl.Colour.Red, new PositionOnBoard(2, 0), this);
        redPieces.Add(theboard[2, 0]);

        theboard[6, 0] = new Bishop(PieceControl.Colour.Red, new PositionOnBoard(6, 0), this);
        redPieces.Add(theboard[6, 0]);

        theboard[1, 0] = new Knight(PieceControl.Colour.Red, new PositionOnBoard(1, 0), this);
        redPieces.Add(theboard[1, 0]);

        theboard[7, 0] = new Knight(PieceControl.Colour.Red, new PositionOnBoard(7, 0), this);
        redPieces.Add(theboard[7, 0]);

        theboard[0, 0] = new Rook(PieceControl.Colour.Red, new PositionOnBoard(0, 0), this);
        redPieces.Add(theboard[0, 0]);

        theboard[8, 0] = new Rook(PieceControl.Colour.Red, new PositionOnBoard(8, 0), this);
        redPieces.Add(theboard[8, 0]);

        theboard[1, 2] = new Cannon(PieceControl.Colour.Red, new PositionOnBoard(1, 2), this);
        redPieces.Add(theboard[1, 2]);

        theboard[7, 2] = new Cannon(PieceControl.Colour.Red, new PositionOnBoard(7, 2), this);
        redPieces.Add(theboard[7, 2]);

        theboard[0, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(0, 3), this);
        redPieces.Add(theboard[0, 3]);

        theboard[2, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(2, 3), this);
        redPieces.Add(theboard[2, 3]);

        theboard[4, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(4, 3), this);
        redPieces.Add(theboard[4, 3]);

        theboard[6, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(6, 3), this);
        redPieces.Add(theboard[6, 3]);

        theboard[8, 3] = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(8, 3), this);
        redPieces.Add(theboard[8, 3]);

        //theboard[4, 8] = new King(PieceControl.Colour.Black, new PositionOnBoard(4, 8));
        //theboard[3, 2] = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(3, 2));
        //theboard[4, 2] = new Knight(PieceControl.Colour.Red, new PositionOnBoard(4, 2));
        theboard[4, 8].LinktoBoard(this);
    }

    //for each black piece, get the first legal move from the list, move piece to that location
    internal void processBlackPiecesMove()
    {

      

        foreach(PieceControl piece in blackPieces)
        {
            foreach(PositionOnBoard moveTo in piece.LegalMoves())
            {
                PieceControl[,] copyOftheboard = theboard;
                movePiece(piece, moveTo);
                currentNode.children.Add(new TreeNode( CurrentBoard()));
                theboard = copyOftheboard;


            }
        
        }
    }

    //for each red piece, get the first legal move from the list, move piece to that location
    internal void processRedPiecesMove()
    {
        foreach (PieceControl piece in redPieces)
        {
            movePiece(piece, piece.LegalMoves()[0]);
        }
    }

    //moving a piece, update the board
    private void movePiece(PieceControl piece, PositionOnBoard positionOnBoard)
    {
        //get copy of board
        int [,] theCurrentBoard = CurrentBoard();

        //empty piece from old position
        emptyPosition(piece.position);

        //check the lists to see if there is a piece in new position
        if(theboard[positionOnBoard.Hpos,positionOnBoard.Vpos].pieceID != 0)
        {
            PieceControl otherPiece = theboard[positionOnBoard.Hpos, positionOnBoard.Vpos];
            if(otherPiece.color != piece.color)
            {
                //remove
                removePiece(otherPiece);

                //replace with current piece

            }
        }

        // move piece
        movePiece(piece, positionOnBoard);
        theboard[positionOnBoard.Hpos, positionOnBoard.Vpos] = piece;
        piece.position = positionOnBoard;
        //update board
        //theCurrentBoard = ;
       
    }

    private void removePiece(PieceControl otherPiece)
    {
        if(otherPiece.color == PieceControl.Colour.Red)
        {
            redPieces.Remove(otherPiece);
        }
        else
        {
            blackPieces.Remove(otherPiece);
        }
    }

    private void emptyPosition(PositionOnBoard position)
    {
       theboard[position.Hpos,position.Vpos] = new BlankSpace(new PositionOnBoard(position.Hpos, position.Vpos));
    }

    //loops through the game board to get current board
    internal int[,] CurrentBoard()
    {
        int[,] theCurrentBoard = new int[numberOfRows, numberofColumns];

        for(int i =0; i<numberOfRows;i++)
        {
            for(int j=0;j<numberofColumns;j++)
            {
                theCurrentBoard[i, j] = theboard[i, j].pieceID;
            }
        }

        return theCurrentBoard;
    }

    internal bool isPositionOccupiedbyA(PositionOnBoard position, PieceControl.Colour color)
    {
        return (theboard[position.Hpos, position.Vpos].pieceID != 0) &&  theboard[position.Hpos, position.Vpos].color == color;
    }


    internal bool isPositionOccupied(PositionOnBoard positionOnBoard)
    {
        return isPositionOccupiedbyA(positionOnBoard, PieceControl.Colour.Red) || 
            isPositionOccupiedbyA(positionOnBoard, PieceControl.Colour.Black);
    }
}
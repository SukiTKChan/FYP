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
        //each pieces is added to the board and to the black pieces list

       
        King blackKing = new King(PieceControl.Colour.Black, new PositionOnBoard(4, 9),this);
        theboard[4, 9] = blackKing;
        blackPieces.Add(blackKing);

        Guard blackGuard1 = new Guard(PieceControl.Colour.Black, new PositionOnBoard(3, 9), this);
        theboard[3, 9] = blackGuard1;
        blackPieces.Add(blackGuard1);

        Guard blackGuard2 = new Guard(PieceControl.Colour.Black, new PositionOnBoard(5, 9), this);
        theboard[5, 9] = blackGuard2;
        blackPieces.Add(blackGuard2);

        Bishop blackBishop1 = new Bishop(PieceControl.Colour.Black, new PositionOnBoard(2, 9), this);
        theboard[2, 9] = blackBishop1;
        blackPieces.Add(blackBishop1);

        Bishop blackBishop2 = new Bishop(PieceControl.Colour.Black, new PositionOnBoard(6, 9), this);
        theboard[6, 9] = blackBishop2;
        blackPieces.Add(blackBishop2);

        Knight blackKnight1 = new Knight(PieceControl.Colour.Black, new PositionOnBoard(1, 9), this);
        theboard[1, 9] = blackKnight1;
        blackPieces.Add(blackKnight1);

        Knight blackKnight2 = new Knight(PieceControl.Colour.Black, new PositionOnBoard(7, 9), this);
        theboard[7, 9] = blackKnight2;
        blackPieces.Add(blackKnight2);

        Rook blackRook1 = new Rook(PieceControl.Colour.Black, new PositionOnBoard(0, 9), this);
        theboard[0, 9] = blackRook1;
        blackPieces.Add(blackRook1);

        Rook blackRook2 = new Rook(PieceControl.Colour.Black, new PositionOnBoard(8, 9), this);
        theboard[8, 9] = blackRook2;
        blackPieces.Add(blackRook2);

        Cannon blackCannon1 = new Cannon(PieceControl.Colour.Black, new PositionOnBoard(1, 7), this);
        theboard[1, 7] = blackCannon1;
        blackPieces.Add(blackCannon1);

        Cannon blackCannon2 = new Cannon(PieceControl.Colour.Black, new PositionOnBoard(7, 7), this);
        theboard[7, 7] = blackCannon2;
        blackPieces.Add(blackCannon2);

        Pawn blackPawn1 = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(0, 6), this);
        theboard[0, 6] = blackPawn1;
        blackPieces.Add(blackPawn1);

        Pawn blackPawn2 = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(2, 6), this);
        theboard[2, 6] = blackPawn2;
        blackPieces.Add(blackPawn2);

        Pawn blackPawn3 = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(4, 6), this);
        theboard[4, 6] = blackPawn3;
        blackPieces.Add(blackPawn3);

        Pawn blackPawn4 = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(6, 6), this);
        theboard[6, 6] = blackPawn4;
        blackPieces.Add(blackPawn4);

        Pawn blackPawn5 = new Pawn(PieceControl.Colour.Black, new PositionOnBoard(8, 6), this);
        theboard[8, 6] = blackPawn5;
        blackPieces.Add(blackPawn5);

        //setting up all the red pieces (button half of board)
        //add each pieces to the board and to the red pieces list
        King redKing = new King(PieceControl.Colour.Red, new PositionOnBoard(4, 0), this);
        theboard[4, 0] = redKing;
        redPieces.Add(redKing);

        Guard redGuard1 = new Guard(PieceControl.Colour.Red, new PositionOnBoard(3, 0), this);
        theboard[3, 0] = redGuard1;
        redPieces.Add(redGuard1);

        Guard redGuard2 = new Guard(PieceControl.Colour.Red, new PositionOnBoard(5, 0), this);
        theboard[5, 0] = redGuard2;
        redPieces.Add(redGuard2);

        Bishop redBishop1 = new Bishop(PieceControl.Colour.Red, new PositionOnBoard(2, 0), this);
        theboard[2, 0] = redBishop1;
        redPieces.Add(redBishop1);

        Bishop redBishop2 = new Bishop(PieceControl.Colour.Red, new PositionOnBoard(6, 0), this);
        theboard[6, 0] = redBishop2;
        redPieces.Add(redBishop2);

        Knight redKnight1 = new Knight(PieceControl.Colour.Red, new PositionOnBoard(1, 0), this);
        theboard[1, 0] = redKnight1;
        redPieces.Add(redKnight1);

        Knight redKnight2 = new Knight(PieceControl.Colour.Red, new PositionOnBoard(7, 0), this);
        theboard[7, 0] = redKnight2;
        redPieces.Add(redKnight2);

        Rook redRook1 = new Rook(PieceControl.Colour.Red, new PositionOnBoard(0, 0), this);
        theboard[0, 0] = redRook1;
        redPieces.Add(redRook1);

        Rook redRook2 = new Rook(PieceControl.Colour.Red, new PositionOnBoard(8, 0), this);
        theboard[8, 0] = redRook2;
        redPieces.Add(redRook2);

        Cannon redCannon1 = new Cannon(PieceControl.Colour.Red, new PositionOnBoard(1, 2), this);
        theboard[1, 2] = redCannon1;
        redPieces.Add(redCannon1);

        Cannon redCannon2 = new Cannon(PieceControl.Colour.Red, new PositionOnBoard(7, 2), this);
        theboard[7, 2] = redCannon2;
        redPieces.Add(redCannon2);

        Pawn redPawn1 = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(0, 3), this);
        theboard[0, 3] = redPawn1;
        redPieces.Add(redPawn1);

        Pawn redPawn2 = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(2, 3), this);
        theboard[2, 3] = redPawn2;
        redPieces.Add(redPawn2);

        Pawn redPawn3 = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(4, 3), this);
        theboard[4, 3] = redPawn3;
        redPieces.Add(redPawn3);

        Pawn redPawn4 = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(6, 3), this);
        theboard[6, 3] = redPawn4;
        redPieces.Add(redPawn4);

        Pawn redPawn5 = new Pawn(PieceControl.Colour.Red, new PositionOnBoard(8, 3), this);
        theboard[8, 3] = redPawn5;
        redPieces.Add(redPawn5);

        
        theboard[4, 8].LinktoBoard(this);
    }

    //for each black piece, get all legal move from the list, move piece to that location
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
            foreach (PositionOnBoard moveTo in piece.LegalMoves())
            {
                PieceControl[,] copyOftheboard = theboard;
                movePiece(piece, moveTo);
                currentNode.children.Add(new TreeNode(CurrentBoard()));
                theboard = copyOftheboard;
            }
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

            }
        }

        // move piece
        movePiece(piece, positionOnBoard);
        theboard[positionOnBoard.Hpos, positionOnBoard.Vpos] = piece;
        piece.position = positionOnBoard;
       
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
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PositionOnBoard
{
    /// <summary>
    /// Horizontal Position On Board
    /// </summary>
    private int i;
    /// <summary>
    /// Vertical Position on Board
    /// </summary>
    private int j;
    private int NumberOfHorizontalSpacesOnBoard = 9;
    private int NUmberOfVerticalSpacesONBoard = 10;


    public PositionOnBoard(int hpos, int vpos)
    {
        Hpos = hpos;
        Vpos = vpos;
    }

    public int Hpos
    {
        get
        {
            return i;
        }

        set
        {
     //       if ((value < 0) || (value >= NumberOfHorizontalSpacesOnBoard)) throw new Exception("This position doesnt exist");

            i = value;
        }
    }

    public int Vpos
    {
        get
        {
            return j;

        }

        set
        {
            //   if ((value < 0) || (value >= NUmberOfVerticalSpacesONBoard)) throw new Exception("This position doesnt exist");

            j = value;
        }
    }

    /// <summary>
    /// Returns true if the piece is on its own side of the river, i.e. 0 - 4 (incl) for Red, 5-9 (incl) for black
    /// </summary>
    /// <param name="colorOfPiece"></param>
    /// <returns></returns>
    internal bool OnMySideOfRiver(PieceControl.Colour colorOfPiece)
    {
        if (colorOfPiece == PieceControl.Colour.Red) return j < 5;
        else return j > 4;
    }

    
    internal bool IsOnBoard()
    {
        return (i >= 0) && (i < NumberOfHorizontalSpacesOnBoard) && (j >= 0) && (j < NUmberOfVerticalSpacesONBoard);
    }

    //specifying the palace location for Red pieces
    internal bool IsInMyPalace(PieceControl.Colour colorOfPiece)
    {

        return (i >= 3) && (i <= 5) && (colorOfPiece == PieceControl.Colour.Red ? (j >= 0) && (j <= 2) : (j >= 7) && (j <= 9));
    }

    //specifying the palace location for black pieces
    internal bool IsInOpposingPalace(PieceControl.Colour colorOfPiece)
    {

        return (i >= 3) && (i <= 5) && (colorOfPiece == PieceControl.Colour.Black ? (j >= 0) && (j <= 2) : (j >= 7) && (j <= 9));
    }

    internal bool NotInAnyPalace()
    {
        return !IsInMyPalace(PieceControl.Colour.Red) && !IsInMyPalace(PieceControl.Colour.Black);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Board board;
    BoardAI boardAI;



	// Use this for initialization
	void Start ()
    {
        board = gameObject.GetComponent<Board>();
        board.CreateBoard();
        boardAI = new BoardAI(9, 10);

        List<PositionOnBoard> ans =  boardAI.theboard[7, 2].LegalMoves();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

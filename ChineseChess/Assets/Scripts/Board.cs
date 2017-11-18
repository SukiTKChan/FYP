using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://thesehallways.wordpress.com/2017/09/07/create-a-chessboard-with-2d-arrays/
public class Board : MonoBehaviour
{
    public GameObject [,] boardArray = new GameObject[9,10];
    public GameObject boardSpawnPrefab;
    //public GameObject

    public Material boardMaterial;


    public Color boardLineColor = Color.black;

    public int lengthOfLineRenderer = 20;
    

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //create the board using 2D array
    public void CreateBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                boardArray[i, j] = (GameObject)Instantiate(boardSpawnPrefab, new Vector3(j, 0, i), Quaternion.identity);

                boardArray[i, j].GetComponent<Renderer>().material = boardMaterial;
            }

        }

    }

    public void drawLinesOnBoard()
    {
        //LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        
    }
}

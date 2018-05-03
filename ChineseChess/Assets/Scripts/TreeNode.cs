using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TreeNode
{
    internal int[,] boardSetup;

    internal List<TreeNode> children;

    public TreeNode(int [,] board)
    {
        children = new List<TreeNode>();
        boardSetup = board;
    }

}


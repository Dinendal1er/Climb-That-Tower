//using UnityEngine;
using System;
//using System.Collections;
using System.Collections.Generic;
//using Completed;
using System.Linq;

public class AStarBitch {

    public int columns;
    public int rows;
    
    private List<AStarNode>    openList;
    private List<AStarNode>    closeList;
    private List<AStarNode>    Map;

    private class AStarNode
    {
        public int pos;
        public bool walkable;
        public int x;
        public int y;
        public int cout_left;
        public int cout;
        public int parent;
        public int poids;

        public AStarNode(int pos, bool w, int x, int y, int h=0, int c=0, int p=-1, int po=-1)
        {
            this.pos = pos;
            this.walkable = w;
            this.x = x;
            this.y = y;
            this.cout_left = h;
            this.cout = c;
            this.parent = p;
            this.poids = po;
        }
    }

    // Use this for initialization
    /*
    void Start () {
        GameObject board = GameObject.Find("GameObject");
        MapGenerator.FieldInfo[] map = board.GetComponent<MapGenerator>().grid;

        this.columns = board.GetComponent<MapGenerator>().columns;
        this.rows = board.GetComponent<MapGenerator>().rows;
        if (map != null)
            Debug.Log("Error : cant catch the map bitch");
        this.buildAStarMap(map);
    }
	*/

    void printMap()
    {
        int i=0;
        while (i < rows * columns)
        {
            Console.Write(this.Map[i].walkable + " ");
           // Debug.Log(this.Map[i].walkable + " ");
            i++;
            if (i % columns == 0)
                Console.Write("\n");
           //     Debug.Log("\n");
        }
    }

	// Update is called once per frame
	void Update () {
        	
	}

    void aStar(int start, int end)
    {
        Map[start].cout = 0;
        Map[start].cout_left = calcHeuristic(start, end, columns, rows);
        this.openList.Add(Map[start]);
        while (this.openList.Count == 0)
        {
            openList = openList.OrderBy(AStarNode=>AStarNode.cout).ToList();
            AStarNode cur = openList.First();
            
        } 
    }
    
    int calcHeuristic(int start, int end, int largeur_map, int hauteur_map)
    {
        int x_start = start % largeur_map;
        int y_start = start / hauteur_map;
        int x_end = end % largeur_map;
        int y_end = end / hauteur_map;

       // int distance = Mathf.Abs(x_start - x_end) + Mathf.Abs(y_start - y_end);
        int distance = Math.Abs(x_start - x_end) + Math.Abs(y_start - y_end);

        return distance;
    }

    void buildAStarMap(Field[] map)
    {
        int i=0;
        while (i < columns * rows)
            {
                Map.Add(new AStarNode(i, isWalkable((int)map[i].type), i % columns, i / columns, 0, 0));
                i++;
            }
    }

    bool isWalkable(int type)
    {
        if (type == 1 || type == 2)
            return true;
        return false;
    }

    static void Main()
    {
        AStarBitch asb = new AStarBitch();
        asb.columns = 10;
        asb.rows = 10;
        Field[] map = new Field[100];
        int i = 0;
        while (i < 100)
        {
            map[i].type = 1;
            i++;
        }
        asb.buildAStarMap(map);
        asb.printMap();
//        asb.aStar(11, 90);


        //...;
    }

    [Serializable]
    public struct Field
    {
        public int type;
        public float height;
    }
}


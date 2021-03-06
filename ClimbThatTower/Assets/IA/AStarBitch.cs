﻿//using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStarBitch
{
    int haut = 0;
    int larg = 0;

    public class AStarNode
    {
        public int pos;
        public bool walkable;
        public int x;
        public int y;
        public float cout_left;
        public float cout;
        public int parent;
        public float poids;   

        public AStarNode(int pos, bool w, int x, int y, int h = 0, int c = 0, int p = -1, int po = 0)
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

    private List<AStarBitch.AStarNode> getNodesAround(List<AStarBitch.AStarNode> map, AStarBitch.AStarNode node)
    {
        List<AStarBitch.AStarNode> ret = new List<AStarBitch.AStarNode>();
        if (node.x > 0)
            ret.Add(map.Find(x => x.pos == (node.pos - 1)));
        if (node.x < larg - 1)
            ret.Add(map.Find(x => x.pos == (node.pos + 1)));
        if (node.y > 0)
            ret.Add(map.Find(x => x.pos == (node.pos - larg)));
        if (node.y < haut - 1)
            ret.Add(map.Find(x => x.pos == (node.pos + larg)));
        return ret;
    }

    private List<AStarBitch.AStarNode> aStar(List<AStarBitch.AStarNode> _map, int hauteur, int largeur, int start, int end)
    {
        // openList contain nodes not analized yet
        List<AStarBitch.AStarNode> openList = new List<AStarBitch.AStarNode>();
        //  closeList contain nodes already analized    
        List<AStarBitch.AStarNode> closeList = new List<AStarBitch.AStarNode>();
        // ret is the list we are gonna return
        List<AStarBitch.AStarNode> ret = new List<AStarBitch.AStarNode>();
        // arrount is a temporary listing of nodes directly arround a specific node. filled with getNodesAround fct
        List<AStarBitch.AStarNode> arround;
        bool sucess = false;
        if (_map == null || start > hauteur * largeur || end > hauteur * largeur || start < 0 || end < 0)
            return (new List<AStarNode>());
        _map[start].cout = 0;
        _map[start].cout_left = calcHeuristic(start, end, largeur, hauteur);
        _map[start].poids = _map[start].cout_left;
        openList.Add(_map[start]);
        while (openList.Count != 0)
        {
            openList = openList.OrderBy(x => x.poids).ToList();
            AStarNode cur = openList.First();
            if (cur.pos == end)
            {
                sucess = true;
                break;
            }
            openList.RemoveAt(0);
            closeList.Add(cur);
            arround = getNodesAround(_map, cur);
            while (arround.Count() != 0)
            {
                AStarNode cur2 = arround.First();
                // ignore the node if it is an obstacle or if it is in the close list
                if (!cur2.walkable || closeList.Exists(x => x.pos == cur2.pos))
                {
                    arround.RemoveAt(0);
                    continue;
                }
                // if the node is not in the oppen list (the close neither), put it in and calcul its parameters
                if (!openList.Exists(x => x.pos == cur2.pos))
                {
                    cur2.parent = cur.pos;
                    cur2.cout = cur.cout + (float) 1;
                    cur2.cout_left = calcHeuristic(cur2.pos, end, larg, haut);
                    cur2.poids = cur2.cout + cur2.cout_left;
                    openList.Add(cur2);
                }
                // if the node is already in the open list, calcul poids
                else
                {
                    float tmppoinds = cur.cout + (float) 1 + calcHeuristic(cur2.pos, end, larg, haut);
                    // if the new poids is under the ancient, replace the parent and recalcul all parameters
                    if (tmppoinds < cur2.poids)
                    {
                        cur2.parent = cur.pos;
                        cur2.cout = cur.cout + 1;
                        cur2.cout_left = calcHeuristic(cur2.pos, end, larg, haut);
                        cur2.poids = cur2.cout + cur2.cout_left;
                    }
                }
                arround.RemoveAt(0);
            }
        }
        if (!sucess)
            return null;
        AStarNode cur3 = openList.First();
        ret.Add(cur3);
        while (cur3.pos != start)
        {
            ret.Add(_map.Find(x => x.pos == cur3.parent));
            cur3 = _map.Find(x => x.pos == cur3.parent);
        }
        return ret;
    }

    private float calcHeuristic(int start, int end, int largeur_map, int hauteur_map)
    {
        int x_start = start % largeur_map;
        int y_start = start / largeur_map;
        int x_end = end % largeur_map;
        int y_end = end / largeur_map;
        float distance = (float) Math.Sqrt(Math.Pow(Math.Abs(x_start - x_end), 2) + Math.Pow(Math.Abs(y_start - y_end), 2));
        return distance;
    }

    private List<AStarBitch.AStarNode> buildAStarMap(MapGenerator.FieldInfo[] map, int hauteur, int largeur)
    {
        List<AStarBitch.AStarNode> ret = new List<AStarBitch.AStarNode>();
        int size = hauteur * largeur;
        int i = 0;
        while (i < size)
        {
            ret.Add(new AStarBitch.AStarNode(i, isWalkable((int)map[i].ftype), i % (largeur), i / (largeur)));
            i++;
        }
        return ret;
    }

    private bool isWalkable(int type)
    {
        return true;
        if (type == 1 || type == 2)
            return true;
        return false;
    }

    public static List<AStarBitch.AStarNode> Astarfct(MapGenerator.FieldInfo[] map, int hauteur_map, int largeur_map, int start, int end)
    {
        AStarBitch asb = new AStarBitch();
        asb.haut = hauteur_map;
        asb.larg = largeur_map;
        List<AStarBitch.AStarNode> _ret = null;
        List<AStarBitch.AStarNode> _map = null;
        _map = asb.buildAStarMap(map, hauteur_map, largeur_map);
        _ret = asb.aStar(_map, hauteur_map, largeur_map, start, end);
        return _ret;
    }
}

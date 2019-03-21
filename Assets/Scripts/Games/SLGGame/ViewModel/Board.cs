using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    public Dictionary<Point, Tile> tiles = new Dictionary<Point, Tile>();

    public void Load(LevelData data)
    {
        for (int i = 0; i < data.tiles.Count; ++i)
        {
            GameObject ins = Instantiate(tilePrefab) as GameObject;
            Tile t = ins.GetComponent<Tile>();
            t.Load(data.tiles[i]);
            tiles.Add(t.pos, t);
        }
    }
}

using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace AgentMovement
{
    public class GridManager : MonoBehaviour
    {
        /// <summary>
        ///     
        /// </summary>
        [SerializeField]
        public static Grid Grid;
        /// <summary>
        ///     
        /// </summary>
        [SerializeField]
        private List<GameObject> tiles;
        /// <summary>
        ///     
        /// </summary>
        public LayerMask UnwalkableMask;
        /// <summary>
        ///     
        /// </summary>
        public int IslandCount;
        /// <summary>
        ///     
        /// </summary>
        public Vector2 GridWorldSize;
        /// <summary>
        ///     
        /// </summary>
        public float NodeSize;
        /// <summary>
        ///     
        /// </summary>
        public bool DisplayGridGizmos;

        /// <summary>
        ///     
        /// </summary>
        void Start() {
            Grid = new Grid(UnwalkableMask, GridWorldSize, NodeSize, transform);
            GenerateTiles();
            AddIsland();
        }

        /// <summary>
        ///     
        /// </summary>
        private void GenerateTiles() {
            GameObject refTile = (GameObject)Instantiate(Resources.Load("WaterTile"));
            foreach(PathNode node in Grid.GridContainer)
            {
                Console.WriteLine(node);
                GameObject tile = Instantiate(refTile, transform);
                float posX = node.X * NodeSize;
                float posY = node.Y * NodeSize;
                tile.transform.position = new Vector2(posX, posY);
                tiles.Add(tile);
            }
            Destroy(refTile);
        }
        /// <summary>
        ///     
        /// </summary>
        private void AddIsland() {
            GameObject refTile = (GameObject)Instantiate(Resources.Load("GrassTile"));
            System.Random rndCount = new System.Random();

            for (int x = 0; x <= IslandCount; x++)
            {
                GameObject tileObj = Instantiate(refTile, transform);

                int r = rndCount.Next(tiles.Count);

                Vector2 tileFoundPos = tiles[r].transform.position;

                tileObj.transform.position = new Vector2(tileFoundPos.x, tileFoundPos.y);

                Destroy(tiles[r]);

                tiles[r] = tileObj;
            }
            Destroy(refTile);
        }

        /// <summary>
        ///     
        /// </summary>
        //void OnDrawGizmos()
        //{
        //    Gizmos.DrawWireCube(transform.position, new Vector3(Grid.GridWorldSize.x, Grid.GridWorldSize.y, 1));
        //    if (Grid != null && Grid.GridContainer.Length >= 1 && DisplayGridGizmos)
        //    {
        //        foreach (PathNode n in Grid.GridContainer)
        //        {
        //            Gizmos.color = (n.Walkable) ? Color.white : Color.red;
        //            Gizmos.DrawCube(n.WorldPos, Vector3.one * (Grid.NodeDiameter - .1f));
        //        }
        //    }
        //}
    }
}
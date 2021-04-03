using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using GlobalUtils;

namespace AgentMovement
{
    class GridManager : MonoBehaviour
    {
        public int Row, Col;
        public int BlockedChance;
        public List<string> WalkableTiles, BlockedTiles;

        private Grid mainGrid;
        private CameraController cameraController;
        private List<GameObject> tiles;

        private void Start()
        {
            tiles = new List<GameObject>();
            cameraController = FindObjectOfType<CameraController>();
            InsantiateGrid(WalkableTiles, BlockedTiles);
            cameraController.StartCameraMovement(new Vector2(mainGrid.RowLength / 2, mainGrid.ColLength / 2));

            Pathfinding pathfinding = new Pathfinding();
            mainGrid.Nodes[0].NodeObject.GetComponent<SpriteRenderer>().color = Color.green;
            mainGrid.Nodes[mainGrid.Nodes.Count - 1].NodeObject.GetComponent<SpriteRenderer>().color = Color.red;
            pathfinding.AStar(mainGrid, mainGrid.Nodes[0], mainGrid.Nodes[mainGrid.Nodes.Count - 1]).ForEach(item => item.NodeObject.SetActive(false));
        }

        private void InsantiateGrid(List<string> walkableTiles, List<string> blockedTiles)
        {
            mainGrid = new Grid(Row, Col, BlockedChance);
            mainGrid.CreateGrid();
            mainGrid.Nodes.ForEach(node =>
            {
                var tileName = node.Walkable ? Utils.GetRandomItemFromList(walkableTiles) : Utils.GetRandomItemFromList(blockedTiles);
                var tileGO = Instantiate(Resources.Load(tileName), new Vector3(node.X, node.Y), Quaternion.identity, transform) as GameObject;
                node.NodeObject = tileGO;
                tiles.Add(tileGO);
            });
        }
    }
}

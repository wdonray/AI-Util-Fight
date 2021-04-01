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
            //pathfinding.AStar(mainGrid, mainGrid.Nodes[0], mainGrid.Nodes[mainGrid.Nodes.Count - 1]).ForEach(item => tiles.Contains(item)));
        }

        private void InsantiateGrid(List<string> walkableTiles, List<string> blockedTiles)
        {
            mainGrid = new Grid(Row, Col, BlockedChance);
            mainGrid.CreateGrid();
            mainGrid.Nodes.ForEach(node =>
            {
                var tileName = node.Walkable ? Utils.GetRandomItemFromList(walkableTiles) : Utils.GetRandomItemFromList(blockedTiles);
                var tileGO = Instantiate(Resources.Load(tileName), new Vector3(node.X, node.Y), Quaternion.identity, transform) as GameObject;
                tiles.Add(tileGO);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AgentMovement
{
    class GridManager : MonoBehaviour
    {
        public int Row, Col;
        public int BlockedChance;
        public string WalkableTile, BlockedTile;

        private Grid mainGrid;
        private CameraController cameraController;

        private void Start()
        {
            cameraController = FindObjectOfType<CameraController>();
            InsantiateGrid(WalkableTile, BlockedTile);
            cameraController.StartCameraMovement(new Vector2(mainGrid.RowLength / 2, mainGrid.ColLength / 2));
        }

        private void InsantiateGrid(string walkableTile, string blockedTile)
        {
            mainGrid = new Grid(Row, Col, BlockedChance);
            mainGrid.CreateGrid();
            mainGrid.Nodes.ForEach(node =>
            {
                var tileName = node.Walkable ? walkableTile : blockedTile;
                var tileGO = Instantiate(Resources.Load(tileName), new Vector3(node.X, node.Y), Quaternion.identity, transform) as GameObject;
            });
        }
    }
}

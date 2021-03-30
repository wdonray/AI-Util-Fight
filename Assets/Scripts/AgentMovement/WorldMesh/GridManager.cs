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
        Grid MainGrid;
        private void Start()
        {
            MainGrid = new Grid(Row, Col);
            MainGrid.CreateGrid();
            MainGrid.Nodes.ForEach(node =>
            {
                var tileName = node.Walkable ? "GrassTile" : "WaterTile";
                var tileGO = Instantiate(Resources.Load(tileName), new Vector3(node.X, node.Y), Quaternion.identity) as GameObject;
            });
        }
    }
}

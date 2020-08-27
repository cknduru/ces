using System;
using System.Collections.Generic;
using CES2020.Models;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace CES2020.Services
{
    public class RuteberegningService
    {
        public ShortestPathResult shortestPath(List<Forbindelse> forbindelser, List<By> byer, int fra, int til)
        {
            var graph = new Graph<int, string>();
            foreach (By by in byer)
            {
                graph.AddNode(by.Id);
            }

            foreach (Forbindelse forbindelse in forbindelser)
            {
                graph.Connect((uint)forbindelse.Fra.Id, (uint)forbindelse.Til.Id, forbindelse.Tid, "Tid");
            }
            ShortestPathResult result = graph.Dijkstra((uint)fra, (uint)til); //result contains the shortest path

            return result;

        }
    }
}

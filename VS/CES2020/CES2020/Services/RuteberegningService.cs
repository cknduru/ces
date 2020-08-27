using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CES2020.Models;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace CES2020.Services
{
    public class RuteberegningService
    {
        public IEnumerable<Forbindelse> GetPossibleForbindelser(Forsendelse forsendelse)
        {
            // TODO-wls get actual forbindelser
            var oceanicForbindelser = new Collection<Forbindelse>();
            var eastIndiaForbindelser = new Collection<Forbindelse>();
            var telstarForbindelser = new Collection<TelstarForbindelse>();

            var possibleForbindelser = telstarForbindelser.Where(f => f.Udløbsdato == null || f.Udløbsdato >= forsendelse.Forsendelsesdato).Select(f => f as Forbindelse);

            possibleForbindelser = possibleForbindelser.Concat(oceanicForbindelser);
            possibleForbindelser = possibleForbindelser.Concat(eastIndiaForbindelser);

            return possibleForbindelser;
        }

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

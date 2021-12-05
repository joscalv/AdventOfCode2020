using System.IO;
using System.Linq;

namespace AdventOfCode
{

    public class Day13 : IAdventOfCodeDay<long, long>
    {
        private readonly int _timestamp;
        private readonly int[] _busIds;
        private readonly int[] _allBusIds;
        public Day13()
        {
            var input = File
                  .ReadAllText(Path.Combine("Inputs", "input13.txt"))
                  .Split("\n")
                  .ToArray();
            _timestamp = int.Parse(input[0]);
            _busIds = input[1].Split(',').Where(id => id != "x").Select(int.Parse).ToArray();
            _allBusIds = input[1].Split(',').Select(id => id == "x" ? 1 : int.Parse(id)).ToArray();
        }

        public long ExecutePart1()
        {
            var minDiference = int.MaxValue;
            var minBusId = 0;
            foreach (var busId in _busIds)
            {
                var currentTimespan = 0;

                while (currentTimespan < _timestamp)
                {
                    currentTimespan = currentTimespan + busId;
                }

                if (currentTimespan - _timestamp < minDiference)
                {
                    minDiference = currentTimespan - _timestamp;
                    minBusId = busId;
                }
            }
            return minBusId * minDiference;
        }

        public long ExecutePart2()
        {
            return ExecutePart2(_allBusIds);
        }
        public long ExecutePart2(int[] busIds)
        {
            var maxId = 0;
            var ids = new int[busIds.Count(id => id >= 0)];
            var offsets = new int[busIds.Count(id => id >= 0)];
            int auxIndex = 0;
            for (int i = 0; i < busIds.Length; i++)
            {
                if (busIds[i] > maxId)
                {
                    maxId = busIds[i];
                }
                if (busIds[i] >= 0)
                {
                    ids[auxIndex] = busIds[i];
                    offsets[auxIndex] = i;
                    auxIndex++;
                }
            }

            long time = 0;
            long stepSize = ids[0];

            for (var i = 1; i < ids.Length; i++)
            {
                var bus = ids[i];
                var offset= offsets[i];


                while ((time + offset) % bus != 0)
                {
                    time += stepSize;
                }

                stepSize *= bus;
            }
            return time;
        }
    }
}

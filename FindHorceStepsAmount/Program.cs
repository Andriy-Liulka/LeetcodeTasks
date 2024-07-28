// See https://www.youtube.com/watch?v=tgWTBwjy--A&ab_channel=%D0%A1%D0%B0%D1%88%D0%B0%D0%9B%D1%83%D0%BA%D0%B8%D0%BD

using System.Diagnostics.CodeAnalysis;

int FindDistance(int target_x, int target_y)
{
    int layerNumber = 0;
    var currentPosition = new int[] { 0, 0 };

    HashSet<int[]> previosLayer = new HashSet<int[]>(new Comparer());
    HashSet<int[]> currentLayer = new HashSet<int[]>(new Comparer());
    currentLayer.Add(currentPosition);

    while (!currentLayer.Contains([ target_x, target_y ]))
    {
        var nextLayer = new HashSet<int[]>(new Comparer());
        foreach (var layerRepresenter in currentLayer)
        {
            foreach (var nextCells in NextLayers(layerRepresenter[0], layerRepresenter[1]))
            {
                if (!previosLayer.Contains(nextCells))
                {
                    nextLayer.Add(nextCells);
                }
            }
        }
        currentLayer = nextLayer;
        previosLayer = currentLayer;
        layerNumber++;
    }


    return layerNumber;
}

int[][] NextLayers(int current_x, int current_y)
{
    return
    [
        [current_x+1, current_y+2],[current_x+2, current_y+1],
        [current_x+2, current_y-1],[current_x-2, current_y+1],
        [current_x-1, current_y-2],[current_x-2, current_y-1],
        [current_x-2, current_y+1],[current_x+2, current_y-1],
    ];
}

var result = FindDistance(5,2);
Console.WriteLine(result);


class Comparer : IEqualityComparer<int[]>
{
    public bool Equals(int[]? x, int[]? y)
    {
        return GetHashCode(x) == GetHashCode(y);
    }

    public int GetHashCode([DisallowNull] int[] obj)
    {
        return obj[0].GetHashCode() + obj[1].GetHashCode();
    }
}
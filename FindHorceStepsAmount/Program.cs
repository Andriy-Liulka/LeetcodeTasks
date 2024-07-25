// See https://aka.ms/new-c//https://https://www.youtube.com/watch?v=tgWTBwjy--A&ab_channel=%D0%92%D0%BE%D0%B8%D0%BD%D1%81%D1%82%D0%B2%D1%83%D1%8E%D1%89%D0%B8%D0%B5%D0%90%D0%BC%D0%B5%D1%82%D0%B8%D1%81%D1%82%D1%8B


int FindDistance(int target_x, int target_y)
{
    int layerNumber = 0;
    var currentLayer = new int[] { target_x, target_y };
    while (target_x != currentLayer[0] && target_y != currentLayer[1])
    {
        var currentX = currentLayer[0];
        var currentY = currentLayer[1];

        var allRoundLayers = NextLayers(currentX, currentY);

        for ( var i = 0; i < allRoundLayers.Length; i++ )
        {

        }

        layerNumber++;
    }
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
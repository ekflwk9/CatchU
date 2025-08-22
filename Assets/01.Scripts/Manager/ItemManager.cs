using UnityEngine;

public static class ItemManager
{
    private static bool isStart;

    private static void CheckStart()
    {
        if(!isStart)
        {
            isStart = true;


        }
    }

    public static void RandomItem()
    {
        CheckStart();
    }
}

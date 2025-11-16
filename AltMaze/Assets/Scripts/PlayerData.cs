using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public float[] position;

    public PlayerData(PlayerHandler player)
    {
        level = player.level;

    }

}

using ExitGames.Client.Photon;
using UnityEngine;

public static class PUNSerializationService
{
    private const float ByteCoefficient = 255;
    private const float FloatCoefficient = 1000f;

    public static void Register()
    {
        PhotonPeer.RegisterType(typeof(Color), 50, SerializeColor, DeserializeColor);
        PhotonPeer.RegisterType(typeof(Vector3), 51, SerializeVector3, DeserializeVector3);
        PhotonPeer.RegisterType(typeof(CharacterSettings), 52, SerializeCharacterSettings, DeserializeCharacterSettings);
    }

    public static byte[] SerializeColor(object colorObject)
    {
        Color color = (Color)colorObject;
        byte[] bytes = new byte[4];
        bytes[0] = (byte)(color.r * ByteCoefficient);
        bytes[1] = (byte)(color.g * ByteCoefficient);
        bytes[2] = (byte)(color.b * ByteCoefficient);
        bytes[3] = (byte)(color.a * ByteCoefficient);

        return bytes;
    }

    public static object DeserializeColor(byte[] bytes)
    {
        Color color = new Color();
        color.r = (float)(bytes[0] / ByteCoefficient);
        color.g = (float)(bytes[1] / ByteCoefficient);
        color.b = (float)(bytes[2] / ByteCoefficient);
        color.a = (float)(bytes[3] / ByteCoefficient);

        return color;
    }

    public static byte[] SerializeVector3(object obj)
    {
        Vector3 vector = (Vector3)obj;
        byte[] bytes = new byte[12];

        int x = Mathf.RoundToInt(vector.x * FloatCoefficient);
        int y = Mathf.RoundToInt(vector.y * FloatCoefficient);
        int z = Mathf.RoundToInt(vector.z * FloatCoefficient);

        System.BitConverter.GetBytes(x).CopyTo(bytes, 0);
        System.BitConverter.GetBytes(y).CopyTo(bytes, 4);
        System.BitConverter.GetBytes(z).CopyTo(bytes, 8);

        return bytes;
    }

    public static object DeserializeVector3(byte[] bytes)
    {
        float x = System.BitConverter.ToInt32(bytes, 0) / FloatCoefficient;
        float y = System.BitConverter.ToInt32(bytes, 4) / FloatCoefficient;
        float z = System.BitConverter.ToInt32(bytes, 8) / FloatCoefficient;

        return new Vector3(x, y, z);
    }

    public static byte[] SerializeCharacterSettings(object obj)
    {
        CharacterSettings settings = (CharacterSettings)obj;
        return settings.ConvertForMessage();
    }

    public static object DeserializeCharacterSettings(byte[] bytes)
    {
        return new CharacterSettings(bytes);
    }
}


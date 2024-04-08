using UnityEngine;

public struct CharacterSettings
{
    private const int ScaleLimit = 12;

    public Color Color;
    public Vector3 Scale;

    public CharacterSettings(Color color, Vector3 scale)
    {
        Color = color;
        Scale = scale;
    }

    public CharacterSettings(byte[] bytes)
    {
        byte[] scale = new byte[12];
        byte[] color = new byte[4];

        for (int i = 0; i < ScaleLimit; i++)
        {
            scale[i] = bytes[i];
        }

        for (int i = ScaleLimit; i < bytes.Length; i++)
        {
            color[i - ScaleLimit] = bytes[i];
        }

        Color = (Color)PUNSerializationService.DeserializeColor(color);
        Scale = (Vector3)PUNSerializationService.DeserializeVector3(scale);
    }

    public byte[] ConvertForMessage()
    {
        byte[] scale = PUNSerializationService.SerializeVector3(Scale);
        byte[] color = PUNSerializationService.SerializeColor(Color);

        byte[] result = new byte[16];
        scale.CopyTo(result, 0);
        color.CopyTo(result, 12);

        return result;
    }
}

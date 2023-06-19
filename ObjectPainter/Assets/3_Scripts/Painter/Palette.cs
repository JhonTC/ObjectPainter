using UnityEngine;

namespace Painter
{
    [System.Serializable]
    public class Palette
    {
        public PaletteData data;

        public IPaint[] paints;

        public void InitialisePaints()
        {
            if (data == null)
            {
                Debug.LogWarning("PaleteData has not been assinged in the inspector.");
                return;
            }

            paints = new IPaint[data.colourPaints.Length + data.texturePaints.Length];

            int index = 0;
            for (int i = 0; i < data.colourPaints.Length; i++)
            {
                paints[index] = data.colourPaints[i];
                index++;
            }

            for (int i = 0; i < data.texturePaints.Length; i++)
            {
                paints[index] = data.texturePaints[i];
                index++;
            }
        }

        public IPaint GetPaintAtIndex(int index)
        {
            if (index == -1) return null;

            return paints[index];
        }
    }
}

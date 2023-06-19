using UnityEngine;

namespace Painter
{
    [CreateAssetMenu(fileName = "new Palette Data", menuName = "PaletteData")]
    public class PaletteData : ScriptableObject
    {
        public ColourPaint[] colourPaints;
        public Texture2DPaint[] texturePaints;
    }
}


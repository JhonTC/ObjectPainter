using UnityEngine;

namespace Painter
{
    public class PaletteDisplay : MonoBehaviour
    {
        [SerializeField]
        private Transform toolbar;

        [SerializeField]
        private PaletteItem paletteItemPrefab;

        private PaletteItem[] paletteItems;

        public void SetupPaletteUI(Palette palette, Painter painter)
        {
            paletteItems = new PaletteItem[palette.paints.Length];
            for (int i = 0; i < paletteItems.Length; i++)
            {
                PaletteItem paletteItem = Instantiate(paletteItemPrefab, toolbar);
                paletteItem.id = i;
                paletteItem.InitialiseMaterial();

                paletteItem.selectPaintButton.onClick.AddListener(() =>
                {
                    painter.selectedPaintIndex = paletteItem.id;
                });

                palette.paints[i].PaintImage(paletteItem.paintIcon);

                paletteItems[i] = paletteItem;
            }
        }
    }
}

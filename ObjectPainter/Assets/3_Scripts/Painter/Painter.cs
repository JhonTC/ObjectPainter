using UnityEngine;

namespace Painter
{
    public class Painter : MonoBehaviour
    {
        [SerializeField]
        private Palette palette;
        [SerializeField]
        private PaletteDisplay paletteDisplay;

        [SerializeField]
        private LayerMask paintableLayer;

        [HideInInspector]
        public int selectedPaintIndex = -1;

        private void Start()
        {
            if (palette != null)
            {
                palette.InitialisePaints();
                paletteDisplay.SetupPaletteUI(palette, this);
            }
        }

        public void OnClick(Vector2 pointerPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(pointerPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 300, paintableLayer))
            {
                PaintablePart part = hit.transform.GetComponent<PaintablePart>();
                if (part != null)
                {
                    PaintPart(part);
                }
            }
        }

        private void PaintPart(PaintablePart part)
        {
            IPaint selectedPaint = palette.GetPaintAtIndex(selectedPaintIndex);

            if (selectedPaint == part.lastPaint) return;

            part.lastPaint?.UndoPaintMaterial(part.meshRenderer.material);
            selectedPaint?.PaintMaterial(part.meshRenderer.material);
            part.lastPaint = selectedPaint;
        }
    }
}

using UnityEngine;

namespace Painter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PaintablePart : MonoBehaviour
    {
        [HideInInspector]
        public MeshRenderer meshRenderer { get; private set; }

        [HideInInspector]
        public IPaint lastPaint;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}

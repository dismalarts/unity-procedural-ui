using UnityEngine;

namespace UIShapeKit
{
    [System.Serializable]
    public struct LinePoint
    {
        [SerializeField] public Vector2 point;
        [SerializeField] public bool isNextCurve;
        [SerializeField] public Vector2 nextCurveOffset;
        [SerializeField] public bool isPrvCurve;
        [SerializeField] public Vector2 prvCurveOffset;
        [SerializeField, Range(1, 100)] public int nextCurveDivideCount;
        [SerializeField, Range(0, 200)] public float width;


        public Vector2 NextCurvePoint
        {
            get => nextCurveOffset + point;
            set => nextCurveOffset = value - point;
        }

        public Vector2 PrvCurvePoint
        {
            get => prvCurveOffset + point;
            set => prvCurveOffset = value - point;
        }

        public float angle;

        public LinePoint(Vector3 p)
        {
            point = p;
            isNextCurve = false;
            isPrvCurve = false;
            nextCurveOffset = Vector3.zero;
            prvCurveOffset = Vector3.zero;
            nextCurveDivideCount = 10;
            width = 10f;
            angle = 0f;

#if UNITY_EDITOR
            isFold = false;
#endif
        }

#if UNITY_EDITOR
        /// <summary>
        /// 이 값은 에디팅에만 필요하고 게임에는 필요 없지만 방법이 없어서 그냥 넣어둠...
        /// </summary>
        public bool isFold;
#endif
    }
}

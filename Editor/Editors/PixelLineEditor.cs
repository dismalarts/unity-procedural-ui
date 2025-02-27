﻿using UIShapeKit.Shapes;
using UnityEditor;
using UnityEditor.UI;

namespace UIShapeKit.Editor.Editors
{
    [CustomEditor(typeof(PixelLine))]
    [CanEditMultipleObjects]
    public class PixelLineEditor : GraphicEditor
    {
        private PixelLine _pixelLine;
        protected SerializedProperty colorProp;
        protected SerializedProperty materialProp;
        protected SerializedProperty raycastTargetProp;

        protected SerializedProperty lineWeightProp;
        protected SerializedProperty snappedPropertiesProp;

        protected override void OnEnable()
        {
            _pixelLine = (PixelLine)target;
            colorProp = serializedObject.FindProperty("m_Color");
            materialProp = serializedObject.FindProperty("m_Material");
            raycastTargetProp = serializedObject.FindProperty("m_RaycastTarget");

            lineWeightProp = serializedObject.FindProperty(nameof(_pixelLine.lineWeight));
            snappedPropertiesProp = serializedObject.FindProperty(nameof(_pixelLine.snappedProperties));
        }

        protected override void OnDisable()
        {
            Tools.hidden = false;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(colorProp);
            EditorGUILayout.PropertyField(materialProp);
            EditorGUILayout.PropertyField(raycastTargetProp);
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(lineWeightProp);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(snappedPropertiesProp, true);

            serializedObject.ApplyModifiedProperties();
        }
    }
}

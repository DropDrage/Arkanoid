using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace NaughtyAttributes.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MonoBehaviour), true)]
    public sealed class NaughtyInspector : UnityEditor.Editor
    {
        private List<SerializedProperty> _serializedProperties = new List<SerializedProperty>();
        private FieldInfo[] _nonSerializedFields;
        private PropertyInfo[] _nativeProperties;
        private MethodInfo[] _methods;

        private Dictionary<string, SavedBool> _foldouts = new Dictionary<string, SavedBool>();


        private void OnEnable()
        {
            _nonSerializedFields = ReflectionUtility.GetAllFields(
                    target, f => f.GetCustomAttributes(typeof(ShowNonSerializedFieldAttribute), true).Length > 0
                )
                .ToArray();

            _nativeProperties = ReflectionUtility.GetAllProperties(
                    target, p => p.GetCustomAttributes(typeof(ShowNativePropertyAttribute), true).Length > 0
                )
                .ToArray();

            _methods = ReflectionUtility.GetAllMethods(
                    target, m => m.GetCustomAttributes(typeof(ButtonAttribute), true).Length > 0
                )
                .ToArray();
        }

        private void OnDisable()
        {
            ReorderableListPropertyDrawer.Instance.ClearCache();
        }


        public override void OnInspectorGUI()
        {
            GetSerializedProperties(ref _serializedProperties);

            var isAnyNaughtyAttributeUsed =
                _serializedProperties.Exists(p => PropertyUtility.GetAttribute<INaughtyAttribute>(p) != null);
            if (!isAnyNaughtyAttributeUsed)
            {
                DrawDefaultInspector();
            }
            else
            {
                DrawSerializedProperties();
            }

            DrawNonSerializedFields();
            DrawNativeProperties();
            DrawButtons();
        }

        private void GetSerializedProperties(ref List<SerializedProperty> outSerializedProperties)
        {
            outSerializedProperties.Clear();
            using (var iterator = serializedObject.GetIterator())
            {
                if (iterator.NextVisible(true))
                {
                    do
                    {
                        outSerializedProperties.Add(serializedObject.FindProperty(iterator.name));
                    } while (iterator.NextVisible(false));
                }
            }
        }

        private void DrawSerializedProperties()
        {
            serializedObject.Update();

            // Draw non-grouped serialized properties
            foreach (var property in GetNonGroupedProperties(_serializedProperties))
            {
                if (property.name.Equals("m_Script", System.StringComparison.Ordinal))
                {
                    using (new EditorGUI.DisabledScope(disabled: true))
                    {
                        EditorGUILayout.PropertyField(property);
                    }
                }
                else
                {
                    NaughtyEditorGUI.PropertyField_Layout(property, includeChildren: true);
                }
            }

            // Draw grouped serialized properties
            foreach (var group in GetGroupedProperties(_serializedProperties))
            {
                var visibleProperties = group.Where(p => PropertyUtility.IsVisible(p)).ToArray();
                if (!visibleProperties.Any())
                {
                    continue;
                }

                NaughtyEditorGUI.BeginBoxGroup_Layout(group.Key);
                foreach (var property in visibleProperties)
                {
                    NaughtyEditorGUI.PropertyField_Layout(property, includeChildren: true);
                }

                NaughtyEditorGUI.EndBoxGroup_Layout();
            }

            // Draw foldout serialized properties
            foreach (var group in GetFoldoutProperties(_serializedProperties))
            {
                var visibleProperties = group.Where(p => PropertyUtility.IsVisible(p)).ToArray();
                if (!visibleProperties.Any())
                {
                    continue;
                }

                if (!_foldouts.ContainsKey(group.Key))
                {
                    _foldouts[group.Key] = new SavedBool($"{target.GetInstanceID()}.{group.Key}", false);
                }

                _foldouts[group.Key].Value = EditorGUILayout.Foldout(_foldouts[group.Key].Value, group.Key, true);
                if (_foldouts[group.Key].Value)
                {
                    foreach (var property in visibleProperties)
                    {
                        NaughtyEditorGUI.PropertyField_Layout(property, true);
                    }
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawNonSerializedFields(bool drawHeader = false)
        {
            if (_nonSerializedFields.Length > 0)
            {
                if (drawHeader)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Non-Serialized Fields", GetHeaderGUIStyle());
                    NaughtyEditorGUI.HorizontalLine(
                        EditorGUILayout.GetControlRect(false), HorizontalLineAttribute.DefaultHeight,
                        HorizontalLineAttribute.DefaultColor.GetColor()
                    );
                }

                foreach (var field in _nonSerializedFields)
                {
                    NaughtyEditorGUI.NonSerializedField_Layout(serializedObject.targetObject, field);
                }
            }
        }

        private void DrawNativeProperties(bool drawHeader = false)
        {
            if (_nativeProperties.Length > 0)
            {
                if (drawHeader)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Native Properties", GetHeaderGUIStyle());
                    NaughtyEditorGUI.HorizontalLine(
                        EditorGUILayout.GetControlRect(false), HorizontalLineAttribute.DefaultHeight,
                        HorizontalLineAttribute.DefaultColor.GetColor()
                    );
                }

                foreach (var property in _nativeProperties)
                {
                    NaughtyEditorGUI.NativeProperty_Layout(serializedObject.targetObject, property);
                }
            }
        }

        private void DrawButtons(bool drawHeader = false)
        {
            if (_methods.Length > 0)
            {
                if (drawHeader)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Buttons", GetHeaderGUIStyle());
                    NaughtyEditorGUI.HorizontalLine(
                        EditorGUILayout.GetControlRect(false), HorizontalLineAttribute.DefaultHeight,
                        HorizontalLineAttribute.DefaultColor.GetColor()
                    );
                }

                foreach (var method in _methods)
                {
                    NaughtyEditorGUI.Button(serializedObject.targetObject, method);
                }
            }
        }

        private static SerializedProperty[] GetNonGroupedProperties(IEnumerable<SerializedProperty> properties) =>
            properties.Where(p => PropertyUtility.GetAttribute<IGroupAttribute>(p) == null)
                .ToArray();

        private static IGrouping<string, SerializedProperty>[] GetGroupedProperties(
            IEnumerable<SerializedProperty> properties) =>
            properties.Where(p => PropertyUtility.GetAttribute<BoxGroupAttribute>(p) != null)
                .GroupBy(p => PropertyUtility.GetAttribute<BoxGroupAttribute>(p).Name)
                .ToArray();

        private static IEnumerable<IGrouping<string, SerializedProperty>> GetFoldoutProperties(
            IEnumerable<SerializedProperty> properties)
        {
            return properties
                .Where(p => PropertyUtility.GetAttribute<FoldoutAttribute>(p) != null)
                .GroupBy(p => PropertyUtility.GetAttribute<FoldoutAttribute>(p).Name)
                .ToArray();
        }

        private static GUIStyle GetHeaderGUIStyle()
        {
            GUIStyle style = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.UpperCenter;

            return style;
        }
    }
}

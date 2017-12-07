using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ObjectPoolFactory))]
    [CanEditMultipleObjects]
    public class ObjectPoolFactoryEditor : UnityEditor.Editor
    {
        public ObjectPoolFactory PoolFactory;

        private void OnEnable()
        {
            PoolFactory = (ObjectPoolFactory) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Object To Pool", GUILayout.Width(175));
            PoolFactory.ObjectToAdd =
                (GameObject) EditorGUILayout.ObjectField(PoolFactory.ObjectToAdd, typeof(Object), true);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            if (GUILayout.Button("Add Object"))
            {
                PoolFactory.AddObjectToBePooled(PoolFactory.ObjectToAdd);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Object Pooler Name: ", GUILayout.Width(175));
            PoolFactory.PoolName = GUILayout.TextArea(PoolFactory.PoolName);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            PoolFactory.PoolQuantity = EditorGUILayout.IntField("# Of Each Object To Pool:", PoolFactory.PoolQuantity);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            PoolFactory.EnableGrowth = EditorGUILayout.Toggle("Enable Dynamic Pool Growth: ", PoolFactory.EnableGrowth);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.Space();
            
            if (GUILayout.Button("Generate Pooling Object"))
            {
                PoolFactory.GeneratePoolingObject();
            }
            
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            if (GUILayout.Button("Clear All"))
            {
                PoolFactory.ClearAllOptions();
            }
        }
    }
}
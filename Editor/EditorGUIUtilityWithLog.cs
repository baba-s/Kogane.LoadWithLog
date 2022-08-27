using UnityEditor;
using UnityEngine;

namespace Kogane
{
    public static class EditorGUIUtilityWithLog
    {
        public static void PingObject( string assetPath )
        {
            var asset = AssetDatabaseWithLog.LoadAssetAtPath<Object>( assetPath );

            EditorGUIUtility.PingObject( asset );
        }
    }
}
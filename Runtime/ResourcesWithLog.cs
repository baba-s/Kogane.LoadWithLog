using UnityEngine;

namespace Kogane
{
    public static class ResourcesWithLog
    {
        public static T Load<T>( string path ) where T : Object
        {
            var result = Resources.Load<T>( path );

            if ( result == null )
            {
                Debug.LogWarning( $"{path} に紐づく {typeof( T ).Name} の Resources.Load に失敗しました" );
            }

            return result;
        }
    }
}
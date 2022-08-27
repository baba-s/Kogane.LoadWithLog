using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Kogane
{
    public static class ResourcesWithLog
    {
        public delegate void OnFailureLoadDelegate( string path, Type type );

        public static OnFailureLoadDelegate OnFailureLoad { get; set; } =
            ( path, type ) => Debug.LogError( $"{path} に紐づく {type.Name} の Resources.Load に失敗しました" );

        public static T Load<T>( string path ) where T : Object
        {
            var result = Resources.Load<T>( path );

            if ( result == null )
            {
                OnFailureLoad?.Invoke( path, typeof( T ) );
            }

            return result;
        }
    }
}
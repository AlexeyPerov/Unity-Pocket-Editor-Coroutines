using System;
using System.Collections;
using UnityEditor;

namespace PocketEditorCoroutines
{
    public class PocketEditorCoroutine
    {
        private readonly bool _hasOwner;
        private readonly WeakReference _ownerReference;
        private IEnumerator _routine;
        private double? _lastTimeWaitStarted;

        public static PocketEditorCoroutine Start(IEnumerator routine, EditorWindow owner = null)
        {
            return new PocketEditorCoroutine(routine, owner);
        }

        private PocketEditorCoroutine(IEnumerator routine, EditorWindow owner = null)
        {
            _routine = routine ?? throw new ArgumentNullException(nameof(routine));
            EditorApplication.update += OnUpdate;
            if (owner == null) return;
            _ownerReference = new WeakReference(owner);
            _hasOwner = true;
        }

        public void Stop()
        {
            EditorApplication.update -= OnUpdate;
            _routine = null;
        }
        
        private void OnUpdate()
        {
            if (_hasOwner && _ownerReference is null or { IsAlive: false })
            {
                Stop();
                return;
            }
            
            var result = MoveNext(_routine);
            if (!result.HasValue || result.Value) return;
            Stop();
        }

        private bool? MoveNext(IEnumerator enumerator)
        {
            if (enumerator.Current is not float current) 
                return enumerator.MoveNext();
            
            _lastTimeWaitStarted ??= EditorApplication.timeSinceStartup;
            
            if (!(_lastTimeWaitStarted.Value + current
                  <= EditorApplication.timeSinceStartup))
                return null;

            _lastTimeWaitStarted = null;
            return enumerator.MoveNext();
        }
    }
}
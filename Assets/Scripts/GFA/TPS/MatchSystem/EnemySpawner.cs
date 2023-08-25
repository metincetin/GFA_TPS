using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


namespace GFA.TPS.MatchSystem
{
    public class EnemySpawner : MonoBehaviour
    {

        private Camera _camera;

        private Plane _plane = new Plane(Vector3.up, Vector3.zero);

        [SerializeField]
        private float _offset;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            StartCoroutine(CreateEnemy());
        }

        private Vector3 GetSpawnOffsetByViewportPosition(Vector3 vector, float sign)
        {
            return vector * sign * _offset;
        }

        private IEnumerator CreateEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                var viewportPoint = Vector3.zero;

                var offset = Vector3.zero;
                
                if (Random.value > 0.5f)
                {
                    var dir = Mathf.Round(Random.value);
                    viewportPoint = new Vector3(dir, Random.value);
                    
                    offset = GetSpawnOffsetByViewportPosition(Vector3.right, dir < 0.001f ? -1f : 1f);
                }
                else
                {
                    var dir = Mathf.Round(Random.value);
                    viewportPoint = new Vector3(Random.value, dir);
                    
                    offset = GetSpawnOffsetByViewportPosition(Vector3.up, dir < 0.001f ? -1f : 1f);
                }

                
                var ray = _camera.ViewportPointToRay(viewportPoint);

                if (_plane.Raycast(ray, out float enter))
                {
                    var worldPosition = ray.GetPoint(enter) - offset;
                    var inst = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    inst.transform.position = worldPosition;
                }
            }
        }
    }
}

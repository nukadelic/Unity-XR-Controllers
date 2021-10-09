
using UnityEngine;

namespace XrControllers
{
    public class XrcArrow : MonoBehaviour
    {
        readonly static float ConeMeshSize = 0.01f;
        readonly static float LineLength = 0.5f;
        readonly static int MatNameID_Color = Shader.PropertyToID("_BaseColor");

        [Header("Reference")]
        [SerializeField] Transform cone;
        [SerializeField] Transform line;

        [Header("Values")]
        [Range(0, 3)] public float scale = 1f;
        [Range(0, 1)] public float tMin = 0;
        [Range(0, 1)] public float tMax = 1;
        public bool visibleCone = true;

        void OnValidate()
        {
            var v = tMin;
            tMin = Mathf.Min( tMax, tMin );
            tMax = Mathf.Max( tMax, v );
        }

        public void SetColor( Color c )
        {
            foreach( var renderer in GetComponentsInChildren<MeshRenderer>() )

                renderer.material.SetColor( MatNameID_Color , c );
        }

        public void PointWorld( Vector3 world_from , Vector3 world_to )
        {
            transform.position = world_from;
            transform.rotation = Quaternion.LookRotation(world_to - world_from);

            var cone_size = visibleCone ? scale * ConeMeshSize : 0;
            var dist = world_to - world_from;
            var start = world_from + dist * tMin;
            var end = start + dist * ( tMax - tMin );
            var len = ( end - start ).magnitude - cone_size;
            
            line.localScale = new Vector3( scale , scale, len / LineLength );
            line.localPosition = Vector3.forward * dist.magnitude * tMin;

            cone.gameObject.SetActive( visibleCone );
            cone.localScale = Vector3.one * ( scale );
            cone.localPosition = new Vector3( 0, 0, end.magnitude - cone_size );
        }

        public void PointLocal( Vector3 local_postiion , Quaternion local_rotation, float length )
        {
            var cone_size = visibleCone ? scale * ConeMeshSize : 0;
            var start = local_rotation * Vector3.forward * tMin * length;
            
            length = length * ( tMax - tMin ) - cone_size;
            
            transform.localPosition = local_postiion;
            transform.localRotation = local_rotation;
            
            line.localScale = new Vector3( scale, scale, length / LineLength);
            line.localPosition = start;

            cone.gameObject.SetActive( visibleCone );
            cone.localScale = Vector3.one * scale;
            cone.localPosition = new Vector3(0, 0, length ) + start;
        }

        // // test
        //public Vector3 posOrRot; public bool local = false; public float size = 1f; public Color color = Color.red;
        //void Update()
        //{
        //    if (local) PointLocal(Vector3.zero, Quaternion.Euler(posOrRot), size);
        //    else PointWorld(Vector3.zero, Vector3.zero + posOrRot);
        //    SetColor(color);
        //}
    }
}
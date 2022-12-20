using UnityEngine;
using Random = System.Random;

namespace Project.Scripts.Fractures
{
    public class FractureThis : MonoBehaviour
    {
        [SerializeField] private Anchor anchor = Anchor.Bottom;   // 기준점
        [SerializeField] private int chunks = 500;              // 부서질갯수
        [SerializeField] private float density = 50;            // 밀도 
        [SerializeField] private float internalStrength = 100;   // 강도
            
        [SerializeField] private Material insideMaterial;        // 내부 메테리얼
        [SerializeField] private Material outsideMaterial;       // 외부 메테리얼

        private Random rng = new Random();

        private void Start()
        {
            FractureGameobject();
            gameObject.SetActive(false);
        }

        public ChunkGraphManager FractureGameobject()
        {
            var seed = rng.Next();
            return Fracture.FractureGameObject(
                gameObject,
                anchor,
                seed,
                chunks,
                insideMaterial,
                outsideMaterial,
                internalStrength,
                density
            );
        }
    }
}
using UnityEngine;
using Random = System.Random;

namespace Project.Scripts.Fractures
{
    public class FractureThis : MonoBehaviour
    {
        [SerializeField] private Anchor anchor = Anchor.Bottom;   // ������
        [SerializeField] private int chunks = 20;              // �μ�������
        [SerializeField] private float density = 2;            // �е� 
        [SerializeField] private float internalStrength = 1;   // ����
            
        [SerializeField] private Material insideMaterial;        // ���� ���׸���
        [SerializeField] private Material outsideMaterial;       // �ܺ� ���׸���

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
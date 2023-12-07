using UnityEngine;
using UnityEngine.AI;

namespace GameScene
{
    public class MonsterAI : MonoBehaviour
    {
        public NavMeshAgent ai;
        public Animator anim;
        public Transform player;
        Vector3 dest;

        void Update()
        {
            dest = player.position;
            ai.destination = dest;
            if (PickupLetter.pagesCollected == 1)
            {
                ai.speed = 6f;
                anim.speed = 1f;
            }
            if (PickupLetter.pagesCollected == 2)
            {
                ai.speed = 8f;
                anim.speed = 1.3f;
            }
            if (PickupLetter.pagesCollected == 3)
            {
                ai.speed = 10f;
                anim.speed = 1.6f;
            }
            if (PickupLetter.pagesCollected == 4)
            {
                ai.speed = 12f;
                anim.speed = 1.9f;
            }
            if (PickupLetter.pagesCollected == 5)
            {
                ai.speed = 13f;
                anim.speed = 2.1f;
            }
            if (PickupLetter.pagesCollected == 6)
            {
                ai.speed = 14f;
                anim.speed = 2.3f;
            }
        }
    }
}
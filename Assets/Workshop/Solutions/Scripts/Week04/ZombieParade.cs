using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solution
{
    public class ZombieParade : OOPEnemy
    {
        // ใช้ LinkedList ในการจัดการส่วนของงูเพื่อประสิทธิภาพในการเพิ่ม/ลบ
        // ใช้ LinkedList ในการจัดการส่วนของงูเพื่อประสิทธิภาพในการเพิ่ม/ลบ
        private LinkedList<GameObject> Parade = new LinkedList<GameObject>();
        public int SizeParade = 3;
        int timer = 0;
        public GameObject[] bodyPrefab; // Prefab ของส่วนลำตัวงู
        public float moveInterval = 0.5f; // ช่วงเวลาในการเคลื่อนที่ (0.5 วินาที)

        private Vector3 moveDirection;

        public  void Start()
        {
            moveDirection = Vector3.up;
            // เริ่ม Coroutine สำหรับการเคลื่อนที่
            positionX = (int)transform.position.x;
            positionX = (int)transform.position.y;
            StartCoroutine(MoveParade());
        }
        private Vector3 RandomizeDirection()
        {
            List<Vector3> possibleDirections = new List<Vector3>
            {
                Vector3.up,
                Vector3.down,
                Vector3.left,
                Vector3.right
            };

            return possibleDirections[Random.Range(0, possibleDirections.Count)];
        }
        // Coroutine สำหรับการเคลื่อนที่ทีละช่อง
        IEnumerator MoveParade()
        {      
            //0. สร้างหัวงู
            while (isAlive)
            {
                
                yield return new WaitForSeconds(moveInterval);
            }
        }
        private bool IsCollision(int x, int y)
        {
            // 4. ตรวจสอบสิ่งกีดขวาง
            if (HasPlacement(x, y))
            {
                return true;
            }
            return false;
        }
        
        // ฟังก์ชันสำหรับเพิ่มส่วนของงู (Grow)
        private void Grow()
        {
           
        }

    }
}

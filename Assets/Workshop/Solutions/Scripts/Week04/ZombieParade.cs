using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solution
{
    public class ZombieParade : OOPEnemy
    {
        // ใช้ LinkedList เก็บ GameObject ทุกส่วนของขบวน
        private LinkedList<GameObject> Parade = new LinkedList<GameObject>();
        public int SizeParade = 3;
        int stepCounter = 0; // เปลี่ยนชื่อจาก timer เป็น stepCounter เพื่อความเข้าใจ
        public GameObject[] bodyPrefab; 
        public float moveInterval = 0.5f; 

        private Vector3 moveDirection;

        public void Start()
        {
            // เชื่อมต่อ MapGenerator ให้เรียบร้อย
            mapGenerator = FindObjectOfType<OOPMapGenerator>();
            
            // เริ่มต้นทิศทาง
            moveDirection = Vector3.up;
            
            // แอดตัวเอง (หัวขบวน) เข้าไปใน LinkedList เป็นตัวแรก
            Parade.AddFirst(this.gameObject);
            
            if (isAlive && mapGenerator != null)
            {
                StartCoroutine(MoveParade());
            }
        }

        private Vector3 RandomizeDirection()
        {
            List<Vector3> possibleDirections = new List<Vector3>
            {
                Vector3.up, Vector3.down, Vector3.left, Vector3.right
            };
            return possibleDirections[Random.Range(0, possibleDirections.Count)];
        }

        IEnumerator MoveParade()
        {      
            while (isAlive)
            {
                // 1. หาตำแหน่งถัดไปโดยอ้างอิงจาก "หัวปัจจุบัน" (Node แรกสุด)
                GameObject currentHead = Parade.First.Value;
                int toX = 0;
                int toY = 0;

                bool isCollision = true;
                int countTryFind = 0;

                // สุ่มหาทางเดินจนกว่าจะเจอช่องที่ว่าง (HasPlacement == false)
                while(isCollision && countTryFind < 10)
                {
                    moveDirection = RandomizeDirection();
                    toX = (int)(currentHead.transform.position.x + moveDirection.x);
                    toY = (int)(currentHead.transform.position.y + moveDirection.y);

                    isCollision = IsCollision(toX, toY);
                    countTryFind++;
                }

                // 2. ถ้าเจอทางเดินที่ไปได้
                if (!isCollision)
                {
                    // กฎของเกมงู: ดึงหางมาเป็นหัว
                    // เก็บ Reference ของโหนดหางเอาไว้
                    LinkedListNode<GameObject> tailNode = Parade.Last;
                    GameObject tailObject = tailNode.Value;

                    // ย้ายตำแหน่งหางไปไว้ที่ตำแหน่งหัวใหม่
                    tailObject.transform.position = new Vector3(toX, toY, 0);

                    // ย้ายโหนดใน LinkedList: ดึงออกจากท้าย แล้วไปเสียบที่หน้าสุด
                    Parade.RemoveLast();
                    Parade.AddFirst(tailNode);

                    // อัปเดตพิกัดตำแหน่งของ Object หลัก (ถ้าจำเป็นต้องใช้ในระบบ Map)
                    positionX = toX;
                    positionY = toY;

                    // 3. ระบบเพิ่มขนาด (Grow)
                    if (Parade.Count < SizeParade)
                    {
                        stepCounter++;
                        if (stepCounter >= 3) // เดินครบ 3 ก้าวให้เพิ่ม 1 ปล้อง
                        {
                            Grow();
                            stepCounter = 0;
                        }
                    }
                }

                yield return new WaitForSeconds(moveInterval);
            }
        }

        private bool IsCollision(int x, int y)
        {
            if (x < 0 || x >= mapGenerator.Cols || y < 0 || y >= mapGenerator.Rows)
            {
                return true; // ถ้าหลุดขอบ ให้ถือว่าเป็นการชน (เดินไปไม่ได้)
            }

            // 2. เช็คว่าตำแหน่งนั้นมีสิ่งกีดขวาง (กำแพง/สิ่งของ) หรือไม่
            if (HasPlacement(x, y))
            {
                return true;
            }

            foreach (GameObject part in Parade)
            {
                // ถ้าตำแหน่งที่จะไป ตรงกับตำแหน่งของปล้องใดๆ ในตัวมันเอง
                if ((int)part.transform.position.x == x && (int)part.transform.position.y == y)
                {
                    // ข้อยกเว้น: ถ้าตำแหน่งนั้นเป็น "หาง" (Last) พอดี มักจะยอมให้เดินได้ 
                    // เพราะหางจะถูกดึงออกไปในจังหวะที่หัวขยับเข้ามาแทนที่พอดี
                    if (part == Parade.Last.Value) 
                        continue; 

                    return true; // ชนตัวเอง!
                }
             }
            return false;
        }
        
        private void Grow()
        {
            if (bodyPrefab.Length > 0 && bodyPrefab[0] != null)
            {
                // สร้างปล้องใหม่
                GameObject newPart = Instantiate(bodyPrefab[0]);
                
                // สำคัญ: ปล้องใหม่ต้องเกิดที่ตำแหน่งเดียวกับ "หาง" ในปัจจุบัน 
                // เพื่อให้รอบถัดไปมันเดินตามกันได้อย่างแนบเนียน
                newPart.transform.position = Parade.Last.Value.transform.position;

                // เพิ่มเข้าไปใน LinkedList ที่ตำแหน่งท้ายสุด
                Parade.AddLast(newPart);
            }
        }
    }
}
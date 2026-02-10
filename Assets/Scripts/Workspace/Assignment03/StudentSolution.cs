using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssignmentSystem.Services;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment03
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture

        public void LCT01_SyntaxLinkedList()
        {
           // 1. สร้าง LinkedList ของประเภท string
            LinkedList<string> linkedList = new LinkedList<string>();

            // 2. เพิ่มข้อมูลที่ท้ายของ LinkedList
            linkedList.AddLast("Node 1");
            linkedList.AddLast("Node 2");

            // 3. เพิ่มข้อมูลที่ต้นของ LinkedList
            linkedList.AddFirst("Node 0");

            // 4. แสดงเนื้อหาใน LinkedList
            LCT01_PrintLinkedList(linkedList);

            // 5. เช้าถึงข้อมูลใน LinkedList
            LinkedListNode<string> firstNode = linkedList.First;
            Debug.Log("first", firstNode.Value);
            LinkedListNode<string> lastNode = linkedList.Last;
            Debug.Log("last", lastNode.Value);
            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Previous.Value);
            Debug.Log(node1.Next.Value);
            if (firstNode.Previous == null)
            {
                Debug.Log("firstNode.Previous is null");
            }
            if (lastNode.Next == null)
            {
                Debug.Log("lastNode.Next is null");
            }

            // 6. add node ก่อน หรือ หลัง node ที่กำหนด
            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");
            LCT01_PrintLinkedList(linkedList);

            // 6. ลบ Node แรก
            linkedList.RemoveFirst();
            LCT01_PrintLinkedList(linkedList);

            // 7. ลบ Node ตามค่าที่กำหนด
            linkedList.Remove("Node 2");
            LCT01_PrintLinkedList(linkedList);
        }

        private void LCT01_PrintLinkedList(LinkedList<string> linkedList)
        {
            Debug.Log("LinkedList...");
            foreach(var node in linkedList)
            {
                Debug.Log(node);
            }
        }

        public void LCT02_SyntaxHashTable()
        {
            
            Hashtable hashtable = new Hashtable();
            //Key Value
            hashtable.Add(1,"Apple");
            hashtable.Add(2,"Banana");
            hashtable.Add("bad-fruit","Rotten Tomato");

            string fruit1 = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit = (string)hashtable["bad-fruit"];

            Debug.Log($"fruit1: {fruit1}");
            Debug.Log($"fruit2: {fruit2}");
            Debug.Log($"badFruit: {badFruit}");

            LCT02_PrintHashTable(hashtable);

            int key = 2;
            if (hashtable.ContainsKey(key))
            {
                Debug.Log($"found {key}");
            }
            else
            {
                Debug.Log($"not found {key}");
            }

            int keyToRemove = 1;
            hashtable.Remove(keyToRemove);
            LCT02_PrintHashTable(hashtable);
        }
        public void LCT02_PrintHashTable(Hashtable hashtable)
        {
            Debug.Log("table ...");
            foreach(DictionaryEntry entry in hashtable)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public void LCT03_SyntaxDictionary()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_CountWords(string[] words)
        {
            throw new System.NotImplementedException();
        }

        public void AS02_CountNumber(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        public void AS03_CheckValidBrackets(string input)
        {
            throw new System.NotImplementedException();
        }

        public void AS04_PrintReverseLinkedList(LinkedList<int> list)
        {
            throw new System.NotImplementedException();
        }

        public void AS05_FindMiddleElement(LinkedList<string> list)
        {
            throw new System.NotImplementedException();
        }

        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            throw new System.NotImplementedException();
        }

        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list)
        {
            throw new System.NotImplementedException();
        }

        public void AS08_TopFrequentNumber(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Extra

        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue)
        {
            throw new System.NotImplementedException();
        }

        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment03
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture

       public void LCT01_SyntaxLinkedList()
        {
            LinkedList<string> linkList = new LinkedList<string>();
            LinkedList<int> ints = new LinkedList<int>();

            ints.AddLast(20);
            Debug.Log(ints);
            for (int i = 0; i < 20 ; i++)
            {
                ints.AddLast(int.Parse(i.ToString()));
                Debug.Log("i = :", i);
            }

            linkList.AddLast("Node 1");
            linkList.AddLast("Node 2");

            linkList.AddFirst("Node 0");
            LCT01_PrintLinkedList(linkList);

            LinkedListNode<string> firstNode = linkList.First;
            Debug.Log("first", firstNode.Value);
            LinkedListNode<string> lastNode = linkList.Last;
            Debug.Log("last", lastNode.Value);

            LinkedListNode<string> node1 = linkList.Find("Node 1"); //หาตัวแรกมาให้เสมอ
            Debug.Log(node1.Previous.Value);
            Debug.Log(node1.Next.Value);

            if(firstNode.Previous == null)
            {
                Debug.Log("firstNode.Previous is null");
            }
            if(lastNode.Next == null)
            {
                Debug.Log("flrstNode.Next is null");
            }

            linkList.AddAfter(node1, "Node 1.5");
            linkList.AddBefore(node1, "Node 0.5");
            LCT01_PrintLinkedList(linkList);

            linkList.RemoveFirst();
            LCT01_PrintLinkedList(linkList);

            linkList.Remove("Node 2");
            LCT01_PrintLinkedList(linkList);
        }

        private void LCT01_PrintLinkedList(LinkedList<string> linkList)
        {
            Debug.Log("LinkedList...");
            foreach (var node in linkList)
            {
                Debug.Log(node);
            }
        }

        public void LCT02_SyntaxHashTable()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add(1, "Apple");
            hashtable.Add(2, "Banana");
            hashtable.Add("bad-fruit", "Rotten Tomato");

            string fruit = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit =  (string)hashtable["bad-fruit"];

            Debug.Log($"fruit: {fruit}");
            Debug.Log($"fruit2 : {fruit2}");
            Debug.Log($"badfruit : {badFruit}");    

            LCT02_PrintHashTable(hashtable);

            int key = 2;
            if(hashtable.ContainsKey(key))
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
                Debug.Log($"Key : {entry.Key}, Value : {entry.Value}");
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

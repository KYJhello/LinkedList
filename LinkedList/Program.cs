﻿namespace LinkedList
{
    internal class Program
    {


        static void Main(string[] args)
        {
            DataStructure.LinkedList<int> linkedList = new DataStructure.LinkedList<int>();

            linkedList.AddFirst(0);
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);

            linkedList.Remove(linkedList.First);


        }
    }
}
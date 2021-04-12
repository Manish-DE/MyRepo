using System;
class LinkedList
{
    public Node head;
    public class Node
    {
        public int data;
        public Node next;
        
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
    
    public void push(int new_data)
    {
        Node New_Node = new Node(new_data);
        New_Node.next = head;
        head = New_Node;
    }

    public void InsertAfter(Node Pre_Node, int New_Data)
    {
        if (Pre_Node == null)
            return;
        Node New_Node = new Node(New_Data);
        New_Node.next = Pre_Node.next;
        Pre_Node.next = New_Node;
    }
    public void append(int New_Data)
    {
        Node New_Node = new Node(New_Data);

        if (head == null)
        {
            head = New_Node;
            return;
        }
        Node last = head;
        while(last.next!= null)
        {
            last = last.next;
        }
        last.next = New_Node;
        return;
    }
    public void PrintNode()
    {
        if (head == null)
            return;
        Node node = head;
        while(node!= null)

        {
            Console.Write(node.data + " ");
            node = node.next;
        }
    }
    public void DeleteNode(int data)
    {
        Node temp = head;
        Node prev = null;
        if (temp == null)
            return;
        
        if (temp != null && temp.data == data)
        {
            head = temp.next;
            temp = null;
            return;
        }
        while(temp != null)
        {
            if (data == temp.data)
                break;
            prev = temp;
            temp = temp.next;
        }
        prev.next = temp.next;
    }
    public void DeletePosition(int position)
    {
        Node temp = head;
        int i = 0;
        if (temp == null || temp.next == null)
            return;
        if (position == 0)
        {
            head = temp.next;
            temp = null;
            return;
        }
        for(int i =0; temp!= null && i < position-1; i++ )
        {
            temp = temp.next;
        }
        Node next = temp.next.next;
        temp.next = next;

            
    }


    public static void Main(String[] args)
    {
        LinkedList list = new LinkedList();
        list.append(6);
        list.push(7);
        list.push(9);
        list.InsertAfter(list.head.next, 10);
        Console.WriteLine("Linked List Value\n");
        list.PrintNode();
        list.DeleteNode(9);
        Console.WriteLine("\nLinked List Value\n");
        list.PrintNode();
        Console.ReadLine();
    }

}
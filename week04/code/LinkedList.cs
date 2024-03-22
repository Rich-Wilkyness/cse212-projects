using System.Collections;
using System.Data.Common;

public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail; 

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value) {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value) {
        // TODO Problem 1
        Node newNode = new Node(value);

        if (_head == null || _tail == null) {
            _head = newNode;
            _tail = newNode;
        } else {
            newNode.Prev = _tail; // connect newNode to the old tail
            _tail.Next = newNode; // connect old tail to newNode
            _tail = newNode; // update tail to be the newNode
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead() {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail) {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null) {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail() {
        // TODO Problem 2
        if (_head == _tail) {
            _head = null;
            _tail = null;
        } else if (_tail != null && _head != null) {
            _tail.Prev!.Next = null; // !. checks to see if it is null already, if not then make it null
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue) {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail) {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value) {
        // TODO Problem 3
        // find value
        if (_head == null || _tail == null) {
            return;
        }
        if (_head.Data == value) {
            RemoveHead();
        }
        else {
            Node currentNode = _head; 
            while (currentNode != null) { // it will = null when we reach the end
                if (currentNode.Data == value) {
                    if (currentNode.Next == null) {
                        RemoveTail();
                        break;
                    } 
                    currentNode.Prev.Next = currentNode.Next; 
                    currentNode.Next.Prev = currentNode.Prev;
                    break;
                }
                else {
                    currentNode = currentNode.Next;
                }
            }
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue) {
        // TODO Problem 4
        if (_head == null || _tail == null) {
            return;
        }
        Node currentNode = _head;
        while (currentNode != null) {
            if (currentNode.Data == oldValue) {
                Node newNode = new Node(newValue);

                if (currentNode.Next == null) {
                    currentNode.Prev.Next = newNode; // set previous node to point at newnode
                    newNode.Next = null;
                    newNode.Prev = currentNode.Prev;
                    _tail = newNode;
                    break;
                } else if (currentNode.Prev == null) {
                    currentNode.Next.Prev = newNode; // set next node to point at newnode
                    newNode.Prev = null;
                    newNode.Next = currentNode.Next;
                    _head = newNode;
                } else {
                    currentNode.Prev.Next = newNode; // set previous node to point at newnode
                    currentNode.Next.Prev = newNode; // set next node to point at newnode
                    newNode.Next = currentNode.Next;
                    newNode.Prev = currentNode.Prev;
                }
                // Remove the old node from the linked list
                currentNode.Prev = null;
                currentNode.Next = null;
                currentNode = newNode.Next;
            } else {
                currentNode = currentNode.Next;
            }
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null) {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse() {
        // TODO Problem 5
        var currentNode = _tail;
        while (currentNode != null) {
            yield return currentNode.Data;
            currentNode = currentNode.Prev;
        }
    }

    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull() {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull() {
        return _head is not null && _tail is not null;
    }
}
/// On a sheet of paper, draw a doubly-linked list and follow along with the following operations shown below. 
/// You should draw new boxes and arrows, and erase boxes and arrows exactly as shown in the reading material above.
/// Begin with a list containing A B C D, then perform the following operations:
/// f1) Insert X at the head.
/// f2) Insert Y in between B and C.
/// f3) Remove D (the tail).
/// f4) Remove B.

// [prev = null] A [next = B] <--> [prev = A] B [next = C] <--> [prev = B] C [next = D] <--> [prev = C] D [next = null]

// function 1 
// determine if list is empty. if empty declare a newNode with prev = null, next = null, and tail = newNode
// else: 
// currentNode = head (A)
// declare newNode [prev = null] X [next = currentNode]
// declare head = newNode (X)
// set currentNode.Prev = X

// function 2
// find B in list
// set currentNode = B
// declare newNode [prev = currentNode] Y [next = currentNode.Next]
// set currentNode.Next.Prev = newNode
// set currentNode.Next = newNode

// function 3 
// set currentNode = tail (D) 
// set currentNode.Prev.Next = null
// set tail = currentNode.Prev

//function 4
// find B in list
// set currentNode = B
// set currentNode.Next.Prev = currentNode.Prev
// set currentNode.Prev.Next = currentNode.Next

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedStream
{
    // https://leetcode.com/contest/weekly-contest-215/problems/design-an-ordered-stream/

    // There are n (id, value) pairs, where id is an integer between 1 and n and value is a string. No two pairs have the same id.
    // Design a stream that takes the n pairs in an arbitrary order, and returns the values over several calls in increasing order of their ids.
    // 
    // Implement the OrderedStream class:
    // OrderedStream(int n) Constructs the stream to take n values and sets a current ptr to 1.
    // String[] insert(int id, String value) Stores the new(id, value) pair in the stream.After storing the pair:
    //   If the stream has stored a pair with id = ptr, then 
    //     find the longest contiguous incrementing sequence of ids starting with id = ptr and 
    //     return a list of the values associated with those ids in order.Then, update ptr to the last id + 1.
    //   Otherwise, return an empty list.

    // Input
    // ["OrderedStream", "insert", "insert", "insert", "insert", "insert"]
    // [[5], [3, "ccccc"], [1, "aaaaa"], [2, "bbbbb"], [5, "eeeee"], [4, "ddddd"]]
    // Output
    // [null, [], ["aaaaa"], ["bbbbb", "ccccc"], [], ["ddddd", "eeeee"]]
    // 
    // Explanation
    // OrderedStream os= new OrderedStream(5);
    // os.insert(3, "ccccc"); // Inserts (3, "ccccc"), returns [].
    // os.insert(1, "aaaaa"); // Inserts (1, "aaaaa"), returns ["aaaaa"].
    // os.insert(2, "bbbbb"); // Inserts (2, "bbbbb"), returns ["bbbbb", "ccccc"].
    // os.insert(5, "eeeee"); // Inserts (5, "eeeee"), returns [].
    // os.insert(4, "ddddd"); // Inserts (4, "ddddd"), returns ["ddddd", "eeeee"].

    public class OrderedStream
    {
        private string[] _stream;
        private int _capacity;

        private int _ptr;

        public OrderedStream(int n)
        {
            // array of 1-based index
            _capacity = n + 1;
            _ptr = 1;

            _stream = new string[_capacity];
        }

        public IList<string> Insert(int id, string value)
        {
            var outStream = new List<string>();

            if (id < _capacity)
            {
                _stream[id] = value;

                if (id == _ptr)
                {
                    while ((_ptr < _capacity) && (!String.IsNullOrEmpty(_stream[_ptr])))
                    {
                        outStream.Add(_stream[_ptr++]);
                    }// while ((_ptr < _capacity) && (!String.IsNullOrEmpty(_stream[_ptr])));

                }
            }

            return outStream;
        }
    }

    //
    // Your OrderedStream object will be instantiated and called as such:
    // OrderedStream obj = new OrderedStream(n);
    // IList<string> param_1 = obj.Insert(id, value);


    class Program
    {
        static void Main(string[] args)
        {
            var orderedStream1 = new OrderedStream(5);

            var result11 = orderedStream1.Insert(3, "ccccc"); // Inserts (3, "ccccc"), returns [].
            var result12 = orderedStream1.Insert(1, "aaaaa"); // Inserts (1, "aaaaa"), returns ["aaaaa"].
            var result13 = orderedStream1.Insert(2, "bbbbb"); // Inserts (2, "bbbbb"), returns ["bbbbb", "ccccc"].
            var result14 = orderedStream1.Insert(5, "eeeee"); // Inserts (5, "eeeee"), returns [].
            var result15 = orderedStream1.Insert(4, "ddddd"); // Inserts (4, "ddddd"), returns ["ddddd", "eeeee"].
            var result16 = orderedStream1.Insert(6, "fffff");
        }
    }
}
